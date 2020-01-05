//as = as || {};
//https://unpkg.com/@zxing/library@latest
var as = {};
as.code_Scanner = {
    options: {
        startDecodeBtn: "",
        resetDecodeBtn: "",
        videoSourceSelect: "",
        videoId: "",
        imgId:"",
        callback: null,
        selectedDeviceId:null
    },
    callbacks: {},
    init: function (options) {
        $this = this;
        $this.options = $.extend($this.options, options);
        if (!$this.options.videoId && !$this.options.imgId) {
            console.log("Укажите ID тега video или img");
            return;
        }
        $this.initCallbacks();
    },
    initCallbacks: function () {
        $this = this;
        const codeReader = new ZXing.BrowserMultiFormatReader();
        if ($this.options.videoId) {
            //работаем с видео
            codeReader.getVideoInputDevices()
                .then((videoInputDevices) => {
                    var sourceSelect = $($this.options.videoSourceSelect);
                    $this.options.selectedDeviceId = videoInputDevices[0].deviceId;
                    if (videoInputDevices.length >= 1 && sourceSelect.length > 0) {
                        videoInputDevices.forEach((element) => {
                            var opt = "<option value='" + element.deviceId + "'>" + element.label + "</option>";
                            sourceSelect.append(opt);
                        });

                        $(document).on('click', $this.options.videoSourceSelect, function () {
                            $this.options.selectedDeviceId = $(this).val();
                            console.log($this.options.selectedDeviceId);
                        });
                    }
                })
                .catch((err) => {
                    console.error(err);
                });
        }

        $(document).on('click', $this.options.startDecodeBtn, function () {
            if ($this.options.videoId) {
                //работаем с видео
                codeReader.decodeFromVideoDevice($this.options.selectedDeviceId, $this.options.videoId, (result, err) => {
                    if (result) {
                        if ($this.options.callback) {
                            $this.options.callback(result);
                        } else {
                            console.log(result);
                        }
                    }
                    if (err && !(err instanceof ZXing.NotFoundException)) {
                        if ($this.options.callback) {
                            $this.options.callback(err);
                        } else {
                            console.log(err);
                        }
                    }
                });
                console.log(`Started continous decode from camera with id `, $this.options.selectedDeviceId);
            }
            else if ($this.options.imgId) {
                //работаем с изображением
                var $img = document.getElementById($this.options.imgId);
                codeReader.decodeFromImage($img).then((result) => {
                    if ($this.options.callback) {
                        $this.options.callback(result);
                    } else {
                        console.log(result);
                    }
                }).catch((err) => {
                    if ($this.options.callback) {
                        $this.options.callback(err);
                    } else {
                        console.log(err);
                    }
                });
                console.log(`Started decode for image from `, $img.src);
            }
        });

        $(document).on('click', $this.options.resetDecodeBtn, function () {
            codeReader.reset();
            console.log('Reset.');
        });
    }
};
