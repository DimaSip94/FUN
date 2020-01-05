using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUN
{
    /// <summary>
    /// Конечный автомат
    /// </summary>
    public class StateMachine
    {
        private enum State { Disabled, Idle, Animating }

        private State currentState;

        public StateMachine()
        {
            setState(State.Disabled);
        }

        //здесь пишем логику входа в состояние A, также можно дописать выход из состояния B
        public void setDisabled()
        {
            ExitState();
            setState(State.Disabled);
        }

        public void setIdle()
        {
            ExitState();
            setState(State.Idle);
        }

        public void setAnimating()
        {
            ExitState();
            setState(State.Animating);
        }

        private void ExitState()
        {
            switch (currentState)
            {
                case State.Animating:
                    Console.WriteLine("Завершить анимацию"); break;
                case State.Idle:
                    Console.WriteLine("Завершить простой"); break;
                case State.Disabled:
                    Console.WriteLine("Завершить отключение"); break;
            }
        }

        /// <summary>
        /// Логика перехода между состояниями
        /// </summary>
        /// <param name="newState"></param>
        private void setState(State newState)
        {
            currentState = newState;
            switch (currentState)
            {
                case State.Animating:
                    Console.WriteLine("Состояние Анимация"); break;
                case State.Idle:
                    Console.WriteLine("Состояние простой"); break;
                case State.Disabled:
                    Console.WriteLine("Состояние отключен"); break;
            }
        }
    }
}
