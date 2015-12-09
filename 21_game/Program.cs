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
            Console.WriteLine("***************************************************");
            Console.WriteLine("********************** Игра 21 ********************");
            Console.WriteLine("***************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Game();

        }

        static void Game()
        {
            bool end = false;
            bool fist = true;

            while (!end)
            {
                if (fist)
                {
                    Console.WriteLine("Для начала игры нажмите 'y', для отмены любую другую клавишу");
                    fist = false;
                }
                else
                {
                    Console.WriteLine("Сыграть еще раз? Для согласия нажмите 'y', для отмены любую другую клавишу");
                }

                ConsoleKeyInfo enter = Console.ReadKey();
                Console.WriteLine();
                char y = 'y';
                if (enter.KeyChar != y)
                {
                    return;
                }

                int userScore, computerScore;
                computerScore = ConputerGame();
                userScore = UserGame();

                ResultGame(computerScore, userScore);

            }
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
                Console.WriteLine("Ваш счет {0}, еще карту? (нажмите 'y' для согласия, и 'n' для завершения кона)", score);

                ConsoleKeyInfo answer = Console.ReadKey();
                Console.WriteLine();
                char y = 'y';

                if (answer.KeyChar == (char)'y' )
                {
                    score += ReturnCard();
                }
                else if (answer.KeyChar == (char)'n')
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

        }

    }
}
