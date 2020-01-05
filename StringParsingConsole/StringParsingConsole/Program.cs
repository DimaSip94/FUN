﻿using System;
using System.Collections.Generic;

namespace StringParsingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = System.IO
                  .File.ReadAllText("files/input.txt");

            //string inputString = "UNB+UNOA:2+FI101:UP+RU101:UP+190515:2224+INTREF0374001'UNH+MESREF000041+PREDES:D:06A:UP:PRED21'BGM++FIVLIZRULEDLAUR90041+9'DTM+164:1905151429:201'DTM+353:190515:101'TDT+20++3++::3'LOC+5+FIVLI::6'LOC+7+RULED::6'EQD+PWN'EQN+121'MEA+WT+AAD+KGM:129.7'CNI+001+FIVLIZRULEDLAUR90041001101297'SGP+BG'MEA+WT+AAB+KGM:129.7'MEA+WT+AAL+KGM:129.7'MEA+CT+CT+NMB:121'FTX+DOC'GID++::::RL005342979RU'MEA+WT+AAA+KGM:0.7'GID++::::RL005343020RU'MEA+WT+AAA+KGM:1.4'GID++::::RL005342951RU'MEA+WT+AAA+KGM:1.6'GID++::::RL005342792RU'MEA+WT+AAA+KGM:1.7'GID++::::RL005342965RU'MEA+WT+AAA+KGM:0.4'GID++::::RL005342996RU'MEA+WT+AAA+KGM:0.2'GID++::::RL005342846RU'MEA+WT+AAA+KGM:1.8'GID++::::RL005343002RU'MEA+WT+AAA+KGM:1.1'GID++::::RL005342801RU'MEA+WT+AAA+KGM:0.5'GID++::::RL005343016RU'MEA+WT+AAA+KGM:0.8'GID++::::RL005342789RU'MEA+WT+AAA+KGM:0.3'GID++::::RL005342863RU'MEA+WT+AAA+KGM:0.3'GID++::::RL005343033RU'MEA+WT+AAA+KGM:0.5'GID++::::RL005342982RU'MEA+WT+AAA+KGM:1.3'GID++::::RL005342775RU'MEA+WT+AAA+KGM:0.5'GID++::::RL005342761RU'MEA+WT+AAA+KGM:0.2'GID++::::RL005342885RU'MEA+WT+AAA+KGM:0.1'GID++::::RL005342815RU'MEA+WT+AAA+KGM:1.1'GID++::::RL005342894RU'MEA+WT+AAA+KGM:1.1'GID++::::RL005342829RU'MEA+WT+AAA+KGM:1.1'GID++::::RL005342877RU'MEA+WT+AAA+KGM:0.2'GID++::::RL005342832RU'MEA+WT+AAA+KGM:0.8'GID++::::RL005342903RU'MEA+WT+AAA+KGM:1.1'GID++::::RL005342850RU'MEA+WT+AAA+KGM:1.6'GID++::::RL005342917RU'MEA+WT+AAA+KGM:0.2'GID++::::RL005342948RU'MEA+WT+AAA+KGM:0.5'GID++::::RL005360853RU'MEA+WT+AAA+KGM:0.1'GID++::::RL005342934RU'MEA+WT+AAA+KGM:1.5'GID++::::RL005342925RU'MEA+WT+AAA+KGM:1.8'GID++::::RJ008625807RU'MEA+WT+AAA+KGM:0.4'GID++::::RJ008625594RU'MEA+WT+AAA+KGM:1.8'GID++::::RJ008625736RU'MEA+WT+AAA+KGM:1.4'GID++::::RJ008625784RU'MEA+WT+AAA+KGM:0.6'GID++::::RJ008625886RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625767RU'MEA+WT+AAA+KGM:0.8'GID++::::RJ008625515RU'MEA+WT+AAA+KGM:0.6'GID++::::RJ008626008RU'MEA+WT+AAA+KGM:0.4'GID++::::RJ008624775RU'MEA+WT+AAA+KGM:0.9'GID++::::RJ008624041RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008624948RU'MEA+WT+AAA+KGM:1.7'GID++::::RJ008625872RU'MEA+WT+AAA+KGM:1.0'GID++::::RJ008625268RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625435RU'MEA+WT+AAA+KGM:0.9'GID++::::RJ008626073RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625841RU'MEA+WT+AAA+KGM:1.3'GID++::::RJ008625550RU'MEA+WT+AAA+KGM:1.3'GID++::::RJ008625546RU'MEA+WT+AAA+KGM:0.9'GID++::::RJ008625492RU'MEA+WT+AAA+KGM:0.8'GID++::::RJ008625705RU'MEA+WT+AAA+KGM:0.4'GID++::::RJ008625824RU'MEA+WT+AAA+KGM:0.8'GID++::::RJ008625603RU'MEA+WT+AAA+KGM:0.9'GID++::::RJ008626246RU'MEA+WT+AAA+KGM:1.2'GID++::::RJ008625237RU'MEA+WT+AAA+KGM:1.0'GID++::::RJ008625311RU'MEA+WT+AAA+KGM:0.4'GID++::::RJ008625254RU'MEA+WT+AAA+KGM:1.7'GID++::::RJ008626087RU'MEA+WT+AAA+KGM:0.5'GID++::::RJ008626192RU'MEA+WT+AAA+KGM:1.0'GID++::::RJ008625427RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625245RU'MEA+WT+AAA+KGM:1.7'GID++::::RJ008625719RU'MEA+WT+AAA+KGM:1.2'GID++::::RJ008625838RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625869RU'MEA+WT+AAA+KGM:0.4'GID++::::RJ008625489RU'MEA+WT+AAA+KGM:0.9'GID++::::RJ008625890RU'MEA+WT+AAA+KGM:0.7'GID++::::RJ008625271RU'MEA+WT+AAA+KGM:1.8'GID++::::RJ008622227RU'MEA+WT+AAA+KGM:1.7'GID++::::RJ008625532RU'MEA+WT+AAA+KGM:1.9'GID++::::RJ008625665RU'MEA+WT+AAA+KGM:1.0'GID++::::RJ008622981RU'MEA+WT+AAA+KGM:1.3'GID++::::RJ008625064RU'MEA+WT+AAA+KGM:1.6'GID++::::RJ008625152RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008622964RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008623908RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008625722RU'MEA+WT+AAA+KGM:1.9'GID++::::RJ008625740RU'MEA+WT+AAA+KGM:1.8'GID++::::RJ008625055RU'MEA+WT+AAA+KGM:1.8'GID++::::RJ008625651RU'MEA+WT+AAA+KGM:1.2'GID++::::RJ008624801RU'MEA+WT+AAA+KGM:2.0'GID++::::RJ008625095RU'MEA+WT+AAA+KGM:1.8'GID++::::RJ008625400RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008625634RU'MEA+WT+AAA+KGM:1.3'GID++::::RJ008625585RU'MEA+WT+AAA+KGM:0.8'GID++::::RJ008625926RU'MEA+WT+AAA+KGM:1.6'GID++::::RJ008626250RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008623925RU'MEA+WT+AAA+KGM:1.0'GID++::::RJ008623956RU'MEA+WT+AAA+KGM:0.8'GID++::::RJ008625413RU'MEA+WT+AAA+KGM:1.4'GID++::::RJ008625930RU'MEA+WT+AAA+KGM:1.4'GID++::::RJ008625149RU'MEA+WT+AAA+KGM:1.9'GID++::::RJ008625373RU'MEA+WT+AAA+KGM:1.9'GID++::::RJ008625170RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008625696RU'MEA+WT+AAA+KGM:1.9'GID++::::RJ008625444RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625387RU'MEA+WT+AAA+KGM:1.8'GID++::::RJ008625943RU'MEA+WT+AAA+KGM:1.7'GID++::::RJ008625356RU'MEA+WT+AAA+KGM:0.6'GID++::::RJ008626232RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008626011RU'MEA+WT+AAA+KGM:1.0'GID++::::RJ008625342RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625855RU'MEA+WT+AAA+KGM:0.6'GID++::::RJ008625461RU'MEA+WT+AAA+KGM:0.7'GID++::::RJ008625775RU'MEA+WT+AAA+KGM:0.6'GID++::::RJ008625458RU'MEA+WT+AAA+KGM:0.4'GID++::::RJ008626135RU'MEA+WT+AAA+KGM:0.7'GID++::::RJ008624925RU'MEA+WT+AAA+KGM:0.3'GID++::::RJ008625815RU'MEA+WT+AAA+KGM:0.6'GID++::::RJ008625501RU'MEA+WT+AAA+KGM:1.2'GID++::::RJ008625798RU'MEA+WT+AAA+KGM:0.5'GID++::::RJ008625912RU'MEA+WT+AAA+KGM:0.5'GID++::::RJ008625395RU'MEA+WT+AAA+KGM:1.4'GID++::::RJ008625753RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008626039RU'MEA+WT+AAA+KGM:1.5'GID++::::RJ008625909RU'MEA+WT+AAA+KGM:0.9'GID++::::RJ008625360RU'MEA+WT+AAA+KGM:0.7'GID++::::RJ008622902RU'MEA+WT+AAA+KGM:0.9'GID++::::RJ008625625RU'MEA+WT+AAA+KGM:1.1'GID++::::RJ008625339RU'MEA+WT+AAA+KGM:1.2'GID++::::RJ008625648RU'MEA+WT+AAA+KGM:2.0'GID++::::RJ008625577RU'MEA+WT+AAA+KGM:0.7'GID++::::RL005010101RU'MEA+WT+AAA+KGM:1.5'GID++::::RL005010115RU'MEA+WT+AAA+KGM:1.0'UNT+259+MESREF000041'UNZ+1+INTREF0374001'";
            string[] splitted = inputString.Split(@"'");
            IList<string> cleaned = new List<string>();
            IList<Parsed> parsed = new List<Parsed>();

            foreach (var item in splitted)
            {
                if (item.StartsWith("GID++::::") || item.StartsWith("MEA+WT+AAA+KGM"))
                {
                    cleaned.Add(item);
                }
            }

            string tempTrackingNumber = null;
            string tempWeight = null;
            int subStringGid = 9;
            int subStringMea = 15;
            foreach (var item in cleaned)
            {
                if (item.StartsWith("GID++::::"))
                {
                    var substring = item.Substring(subStringGid);
                    var itemSub = substring.Substring(0, substring.Length);
                    tempTrackingNumber = itemSub;
                    continue;
                }

                if (item.StartsWith("MEA+WT+AAA+KGM"))
                {
                    string itemSub = item.Substring(subStringMea);
                    tempWeight = itemSub;
                }

                Parsed tempParsed = new Parsed()
                {
                    TrackingNumber = tempTrackingNumber,
                    Weight = tempWeight
                };
                parsed.Add(tempParsed);
            }

            int id = 0;
            foreach (var item in parsed)
            {
                Console.WriteLine($" id: {id} | ШПИ посылки: {item.TrackingNumber} | Вес: {item.Weight} \r\n");
                id++;
            }

            Console.WriteLine("\r\nPress any key to continue ...");
        }
    }
}