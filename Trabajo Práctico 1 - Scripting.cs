using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico1___Scripting___Nicolas_Escobar_Espinosa
{
    class Program
    {
        static void Main (string[] args)
        {
            try
            {
                //Se registran los números tanto como del usuario y el número ganador

                string userBet = ""; //El número de dinero apostado por el usuario
                int bet = 0; //Total de dinero apostado por el usuario
                string userNumber = ""; //El número de chance del usuario

                //Rquerimos datos de entrada ademas de narrativa
                Console.WriteLine("\nSaludos soy Failsafe tu chancera local y de total confianza... , mas que los politicos de turno si soy, veo que quieres apostar algo de dinero... , dinero fácil...");

                Console.WriteLine("\n¿Cuanto vamos a apostar hoy?");
                userBet = Console.ReadLine();

                //Confirmamos que el valor apostado sea mayor a mil pesos
                bet = int.Parse(userBet);
                while (bet < 1000)
                {

                    //de no ser suficiente apuesta se requerira que se vuelva a apostar
                    Console.WriteLine("\nEs muy poco dinero... , parece que en centimetros no es en lo único que estas corto, debes apostar mas");
                    Console.WriteLine("\n¿Cuanto vamos a apostar hoy?");

                    userBet = Console.ReadLine();
                    bet = int.Parse(userBet);
                }

                Console.WriteLine("\n¡Perfecto!, y ¿Cuales serán tus digitos de la suerte... , si es que te queda algo de suerte...");
                Console.WriteLine("\nEscribe los 4 números que vas a jugar, recuerda no puedes jugar mas ni menos de 4 dígios, no escribar letras, caracteres especiales o utilices espacios");
                userNumber = Console.ReadLine();

                //Confirmamos que el número al que se apostó sea valido y no contenga carácteres diferentes
                while( Checker(userNumber) == false )
                {
                    Console.WriteLine("\nParece que no cursamos primaria mi bebe, ese número es incorrecto..., tarado");
                    Console.WriteLine("\nEscribe los 4 números que vas a jugar, recuerda no puedes jugar mas ni menos de 4 dígios");
                    userNumber = Console.ReadLine();
                    Checker(userNumber);
                }

                //Enviamos el número del usuario y lo comparamos
                Console.WriteLine("\n¡Perfecto!, ahora vamos a echar la suerte a rodar y veamos si te ganaste uno de nuestros jugosos premios como por ejemplo... , un kilo de naranjas, uno de limones otro de limas....");
                Console.WriteLine(Comparator(userNumber));
            }
            catch(Exception error)
            {
                Console.WriteLine("\nError fatal y funcional inciando sistema de fallos, ... vaya que la cagaste esta vez, iniciando protocolo de seguridad, ... veo todo oscuro *cof*cof*, borrando base de datos, ... dile a jimmy que no vendré para navidad *cof*cof*, borrando historial de navegacion, ... adios *ble*.... ");
                Console.WriteLine(error);
                Console.ReadKey();
            }
        }

        //Se revisan los valores para encontrar un posible error
        public static bool Checker(string userNumber)
        {
            try
            {
                char[] number = userNumber.ToCharArray();

                if (number.Length != 4) //Confirmamos la longitud del número
                {
                    return false;
                }

                //Confirmamos que sea compuesto de solo números
                char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int count = 0;

                for (int i = 0; i < number.Length; i++)
                {
                    count = 0;

                    for (int k = 0; k < numbers.Length; k++)
                    {
                        if (number[i].Equals(numbers[k]))
                        {
                            count += 1;
                        }
                    }

                    if (count == 0)
                    {
                        return false;
                    }
                }

                //De no ocurrir nada malo, este número será válido y se podra continuar
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine("\nError fatal y funcional inciando sistema de fallos, ... vaya que la cagaste esta vez, iniciando protocolo de seguridad, ... veo todo oscuro *cof*cof*, borrando base de datos, ... dile a jimmy que no vendré para navidad *cof*cof*, borrando historial de navegacion, ... adios *ble*.... ");
                Console.WriteLine(error);
                Console.ReadKey();
                return false;
            }
        }

        //Se comparan los números para encontrar una posible victoría
        public static string Comparator(string userNumber, int bet)
        {
            try
            {
                //Generamos el número a comparar
                int[] winNumber = { 1, 2, 3, 4 };
                int[] winNumbers = { 1, 2, 3, 4 };
                Random numberGenerator = new Random();

                for (int i = 0; i < winNumber.Length; i++)
                {
                    winNumber[i] = numberGenerator.Next(0, 10);
                    winNumbers[i] = winNumber[i]
                }

                //traducimos el número del usuario
                char[] number = userNumber.ToCharArray();
                int[] user = { 0, 0, 0, 0 };
                int[] users = { 0, 0, 0, 0 };
                for (int i = 0; i < user.Length; i++)
                {
                    user[i] = int.Parse(number[i].ToString());
                    users[i] = int.Parse(number[i].ToString());
                }

                int count = 0;

                //Verificamos si tienes 4 cifras iguales en orden
                count = 0;
                for (int i = 0; i < user.Length; i++)
                {
                    if (user[i] == winNumber[i])
                    {
                        count += 1;
                    }
                }
                if (count == 4)
                {
                    return ("Ganaste con 4 cifras en orden el valor de: " + (bet * 4500) );
                }

                //Verificamos si tiene 4 cifras iguales en desorden
                //Ordenamos el número del jugador
                for (int i = 0; i < users.Length; i++)
                {

                    int menorB = users[i];

                    for (int k = i; k < users.Length; k++)
                    {
                        if (menorB > users[k])
                        {
                            int pasar = menorB;
                            menorB = users[k];
                            users[k] = pasar;
                        }
                    }

                    users[i] = menorB;
                }
                //ordenamos el número generado
                for (int i = 0; i < winNumber.Length; i++)
                {

                    int menorB = winNumbers[i];

                    for (int k = i; k < winNumbers.Length; k++)
                    {
                        if (menorB > winNumbers[k])
                        {
                            int pasar = menorB;
                            menorB = winNumbers[k];
                            winNumbers[k] = pasar;
                        }
                    }

                    winNumbers[i] = menorB;
                }
                //verificamos si son iguales ya organizados
                count = 0;
                for (int i = 0; i < user.Length; i++)
                {
                    if (users[i] == winNumbers[i])
                    {
                        count += 1;
                    }
                }
                if (count == 4)
                {
                    return ("Ganaste con 4 cifras en desorden el valor de: " + (bet * 200));
                }

                //Verificamos si tiene los 3 ultimos digitos bien
                count = 0;
                for (int i = user.GetLowerBound(0); i < user.GetUpperBound(0)+1; i++)
                {
                    if (user[i] == winNumber[i])
                    {
                        count += 1;
                    }
                }
                if (count == 3)
                {
                    return ("Ganaste con las 3 últimas cifras en orden el valor de: " + (bet * 400));
                }
                else if(count == 2)
                {
                    return ("Ganaste con las 2 últimas cifras en orden el valor de: " + (bet * 50));
                }
                else if(count == 1)
                {
                    return ("Ganaste con al útima cifra en orden el valor de: " + (bet * 5));
                }

                return "Perdiste";
            }
            catch(Exception error)
            {
                Console.WriteLine("\nError fatal y funcional inciando sistema de fallos, ... vaya que la cagaste esta vez, iniciando protocolo de seguridad, ... veo todo oscuro *cof*cof*, borrando base de datos, ... dile a jimmy que no vendré para navidad *cof*cof*, borrando historial de navegacion, ... adios *ble*.... ");
                Console.WriteLine(error);
                Console.ReadKey();
                return "";
            }
        }
        

    }
}
