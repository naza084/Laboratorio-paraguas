namespace Laboratorio_paraguas
{
    public abstract class Medicamento
    {

        //Propiedades
        protected string _name;
        protected string _id;
        protected Designation _designation;



        //Metodos:



        //Validar name
        public string GetValidName(string message)
        {

            //variable a usar
            string? name;


            do
            {
                Console.Write(message);
                name = Console.ReadLine();

                //Verificamos si no se digito nada
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Error: El nombre no puede estar en blanco.");
                }
                //Verificamos si es numero
                else if (name.Any(char.IsDigit))
                {
                    Console.WriteLine("Error: El nombre no puede contener números.");
                    continue;
                }
                else
                {
                    //Salimos del bucle si es valido
                    break;
                }
            } while (true);

            //Retornamos el nombre válido.
            return name;
        }



        //Generar id
        public abstract string GenerateID();


        //Obtener designacion
        public Designation GetDesignation() { return _designation; }


        //Validar designation
        public static Designation GetValidDesignation()
        {

            //Variables
            int op;
            Designation seleccion;


            //Creamos array de las designaciones como strings
            string[] designations = Enum.GetNames(typeof(Designation));


            //Mostramos los valores de Designation
            Console.WriteLine("Designaciones disponibles: ");
            foreach (string designation in designations)
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(Designation), designation)}. {designation}");
            }


            //Pedimos una designacion
            do
            {
                Console.Write("Selecciona un numero de designacion: ");

                //Verficamos si es un int
                if (int.TryParse(Console.ReadLine(), out op))
                {
                    //Verificamos si el valor esta en el enum
                    if (Enum.IsDefined(typeof(Designation), op))
                    {
                        seleccion = (Designation)op;
                        //Salimos del bucle
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Selecciona una designación válida.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Ingresa un número válido.");
                }
            } while (true);


            //Retornamos designacion
            return seleccion;
        }


        //Mostrar info
        public void GetInfo()
        {
            Console.Write($"{_name} ({_id}) - {_designation}");
        }


        //Obtener nombre
        public string GetName()
        {
            return _name;
        }

    }

    //Designaciones
    public enum Designation { ALFA, BETA, GAMA, EPSILON, OMEGA, TAU }
}