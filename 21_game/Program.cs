using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _21_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************** Игра 21 ********************");

            int userScore, computerScore;
            computerScore = ConputerGame();
            userScore = UserGame();

            ResultGame(computerScore, userScore);

        }

        static int ReturnCard()
        {
            int[] cards = { 11, 4, 3, 2, 10, 9, 8, 7, 6};

            Random RandomCard = new Random();

            return cards[RandomCard.Next(0, cards.Length)];

        }

        static int ConputerGame()
        {
            int score = ReturnCard();

            while (score < 19)
            {
                score += ReturnCard();
            }

            return score;
        }

        static int UserGame()
        {
            int score = ReturnCard();

            while (score < 21)
            {
                Console.WriteLine("Ваш счет {0}, еще карту? (нажмите да, для согласия)", score);

                string answer = Console.ReadLine();

                if (answer == "да" || answer == "Да" || answer == "lf")
                {
                    score += ReturnCard();
                }
                else if (answer == "нет" || answer == "Нет" || answer == "Ytn")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Я Вас не понял, повторите ответ");
                }
                   
            }

            return score;
        }

        static void ResultGame(int computerScore, int userScore)
        {

            if ((computerScore > 21 && userScore < 21) || (computerScore != 21 && userScore == 21) || (computerScore < userScore && computerScore < 22 && userScore < 22))
            {
                Console.WriteLine("Выйграл пользоатель, он набрал {0}, а компьютер набрал {1}", userScore, computerScore);
                return;

            } else if ((computerScore < 21 && userScore > 21) || (computerScore == 21 && userScore != 21) || (computerScore > userScore && computerScore < 22 && userScore < 22))
            {
                Console.WriteLine("Компьютер победил, его счет {1}, а счет пользователя {0}", userScore, computerScore);
                return;

            } else if (computerScore > 21 && userScore > 21)
            {
                Console.WriteLine("Победителя нет, оба набрали больше 21 очка");
                return;
            }
            else
            {
                Console.WriteLine("Победителя нет!");
                return;
            }






            if (userScore == 21)
            {
                if (computerScore == 21)
                {
                    Console.WriteLine("У нас ничья. Оба игрока набрали 21 очко");
                }
                else
                {
                    Console.WriteLine("ВЫ победили");
                }

            }
            else if (computerScore > userScore)
            {
                Console.WriteLine("Компьютер победил, его счет {1}, а счет пользователя {0}", userScore, computerScore);

            }
            else if (computerScore < userScore)
            {
                Console.WriteLine("Выйграл пользоатель, он набрал {0}, а компьютер набрал {1}", userScore, computerScore);

            }
            else
            {
                Console.WriteLine("Ничья! Пользователь наббрал {0}, и компьютер набрал {1}", userScore, computerScore);


            }
        }

    }
}
