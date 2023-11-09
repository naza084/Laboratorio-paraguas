namespace Laboratorio_paraguas
{
    public class Sistema
    {

        //Propiedades
        public List<Sucursal> _sucursals;
        public List<string> _codes;


        //Constructor
        public Sistema()
        {
            _sucursals = new();
            _codes = new();
        }



        //Metodos:


        //Bienvenida 
        public virtual void Welcome()
        {
            Console.WriteLine("Bienvenido al Sistema de Gestión de Vacunas de Corporación Paragüas!");
            Console.WriteLine();
        }


        //Despedida
        public void GoodBye()
        {
            Console.WriteLine("Gracias por utilizar el Sistema de Gestión de Vacunas de Corporación Paragüas. ¡Hasta luego!");
        }



        //Pedir opcion 
        public virtual int GetValidOption(string message)
        {
            //Variable a usar
            int op;

            do
            {
                Console.Write(message);

                //Se repite mientras que op no sea int, no sea menor que 0 y no sea mayor sucursals.count
            } while ((!int.TryParse(Console.ReadLine(), out op)) || op < 0 || op > _sucursals.Count - 1);

            return op;
        }



        //Pedir respuesta
        public static string GetValidAnswer(string message)
        {

            //variable a usar
            string? answer;

            do
            {
                //Pedimos una respuesta
                Console.Write(message);
                answer = Console.ReadLine()?.ToLower();


                //Verificamos si se digito un si o un no
                if (answer != "si" && answer != "no")
                {
                    Console.WriteLine("Por favor, digite 'si' o 'no'.");
                }
                //Verificamos si se digito un espacio en blanco 
                else if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine("Error: La respuesta no puede estar en blanco.");
                }
                //Verificamos si se digito un un numero 
                else if (answer.Any(char.IsDigit))
                {
                    Console.WriteLine("Error: La respuesta no puede contener números.");
                }


            } while (answer != "si" && answer != "no");


            //Devolvemos la respuesta
            return answer;
        }


        //Añadir sucursal 
        public void AddSucursal(Sucursal sucursal)
        {
            _sucursals.Add(sucursal);
        }



        //Mostrar sucursales
        public void DisplayBranches()
        {
            if (_sucursals.Count == 0)
            {
                Console.WriteLine("No hay sucursales disponibles.");
            }
            else
            {
                Console.WriteLine("Lista de sucursales: ");

                for (int i = 0; i < _sucursals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_sucursals[i].GetCode()}");
                }
            }
        }


        //Autodestrucción global
        public virtual void DestructionProcess()
        {

            //Variable a usar
            string op;


            //Verificamos si las sucursales estan vacias
            if (_sucursals.Count == 0)
            {
                Console.WriteLine("No hay sucursales disponibles para ejecutar la autodestrucción global.");
            }

            else
            {
                //Pedimos una opcion
                Console.WriteLine("¡ATENCIÓN! Esto destruirá todos los contenidos en todas las sucursales.");
                op = GetValidAnswer("¿Está seguro de que desea continuar?(Sí/No): ");

                //Recorremos la lista de sucursales y borramos en caso de "si"
                if (op == "si")
                {
                    _sucursals.Clear();
                    Console.WriteLine("Todos las sucursales han sido eliminadas.");
                }
                else
                {
                    Console.WriteLine("No se han borrado las sucursales.");
                }
            }

        }

    }
}