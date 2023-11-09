namespace Laboratorio_paraguas
{
    public class Sucursal : Sistema
    {

        //Propiedades
        private string _code;
        private List<Medicamento> _medicamentos;
        private static Random randal = new();


        //Constructor
        public Sucursal()
        {
            _code = GenerateCode();
            _codes.Add(_code);
            _medicamentos = new();
        }



        //Metodos:


        //Generar codigo
        public static string GenerateCode()
        {

            //Creamos codigo
            int numCode = randal.Next(1, 1000);


            //Retornamos codigo formateado con ceros iniciales para que siempre tenga tres cifras
            return string.Format("SUC{0:000}", numCode);
        }



        //Bienvenida
        public override void Welcome()
        {
            Console.WriteLine();
            Console.WriteLine($"Bienvenido a la Sucursal {_code}");
        }



        //Mostrar menu
        public void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu de opciones: ");
            Console.WriteLine("1.Catalogar nueva vacuna \n2.Sintetizar virus \n3.Destruir vacuna o virus \n4.Destruir por tipo");
            Console.WriteLine("5.Activar sistema de autodestrucción \n6.Activar sistema de autodestrucción global \n7.Salir \n");
        }



        //Pedir opcion 
        public override int GetValidOption(string message)
        {
            //Variable a usar
            int op;

            do
            {
                Console.Write(message);

                //Se repite hasta que se ingrese un int o sea menor a 0 o mayor que 7
            } while ((!int.TryParse(Console.ReadLine(), out op)) || op <= 0 || op > 7);

            return op;
        }



        //Ejecutar opción
        public void ExecuteOption(int op, Sistema system)
        {

            //Ejecutamos la opcion
            switch (op)
            {
                case 1:
                    CatalogarVacuna();
                    break;
                case 2:
                    SintetizarVirus();
                    break;
                case 3:
                    DestruirMedicamente();
                    break;
                case 4:
                    DestroyByType();
                    break;
                case 5:
                    DestructionProcess();
                    break;
                case 6:
                    system.DestructionProcess();
                    break;
                default:
                    Console.WriteLine("Ha vuelto al menú de selección de sucursal.");
                    break;
            }
        }



        //Pedir indice
        public int GetValidIndex(string message)
        {
            //Variable a usar
            int index;

            do
            {
                Console.Write(message);

                //Se repite hasta que se ingrese un int o sea menor a 0 o mayor que 7
            } while ((!int.TryParse(Console.ReadLine(), out index)) || index <= 0 || index > _medicamentos.Count);

            return index;
        }



        //Obtener codigo
        public string GetCode()
        {
            return _code;
        }



        //Mostrar lista de medicamentos
        public void DisplayMedicines()
        {

            Console.WriteLine("Lista de medicamentos disponibles: ");
            for (int i = 0; i < _medicamentos.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _medicamentos[i].GetInfo();
                Console.WriteLine();
            }
        }



        //Catalogar nueva vacuna
        public void CatalogarVacuna()
        {

            //Creamos nueva vacuna
            Vacuna vacuna = new();


            //La añadimos a la lista
            _medicamentos.Add(vacuna);
            Console.WriteLine("Se ha catalogado la nueva vacuna con exito.");

        }



        //Sintetizar virus
        public void SintetizarVirus()
        {

            //Objeto a usar
            Vacuna? ultimaVacunaNoSintetizada = null;


            //Buscamos la última vacuna no sintetizada
            for (int i = _medicamentos.Count - 1; i >= 0; i--)
            {
                if (_medicamentos[i] is Vacuna vacuna && !vacuna.GetEstado())
                {
                    ultimaVacunaNoSintetizada = vacuna;
                    break;
                }
            }


            //Verificamos si se encontro una vacuna sin sintetizar
            if (ultimaVacunaNoSintetizada != null)
            {
                // Verificamos si la última vacuna ya está sintetizada
                if (!ultimaVacunaNoSintetizada.GetEstado())
                {
                    Virus virus = new(ultimaVacunaNoSintetizada.GetDesignation());

                    _medicamentos.Add(virus);
                    //Marcamos la última vacuna como sintetizada
                    ultimaVacunaNoSintetizada.SetEstado(true); 
                    Console.WriteLine("Se ha sintetizado un virus derivado de la última vacuna.");
                }         
            }
            else
            {
                Console.WriteLine("No hay vacunas disponibles para sintetizar un virus.");
            }
        }



        //Destruir vacuna o virus
        public void DestruirMedicamente()
        {

            //Verificamos si hay medicamentos
            if (_medicamentos.Count == 0)
            {
                Console.WriteLine("No hay medicamentos disponibles para destruir.");
                return;
            }


            //Mostramos los medicamentos
            DisplayMedicines();


            //Pedimos un indice del medicamento a destruir
            int index = GetValidIndex("Elija el medicamento a destruir: ");


            //Removemos el medicamento
            Medicamento medicamento = _medicamentos[index - 1];
            Console.WriteLine($"El medicamento '{medicamento.GetName()}' ha sido destruido.");
            _medicamentos.RemoveAt(index - 1);
        }



        //Destruir por tipo
        public void DestroyByType()
        {

            //Variable a usar
            bool tipoEncontrado = false;


            //Verificamos si hay medicamentos
            if (_medicamentos.Count == 0)
            {
                Console.WriteLine("No hay medicamentos disponibles para destruir.");
            }
            else
            {
                //Pedimos un tipo
                Designation type = Medicamento.GetValidDesignation();


                //Buscamos si hay medicamentos de ese tipo
                for (int i = _medicamentos.Count - 1; i >= 0; i--)
                {
                    //Removemos el medicamento en caso de que se encuentre
                    if (_medicamentos[i].GetDesignation() == type)
                    {
                        tipoEncontrado = true;
                        _medicamentos.RemoveAt(i);
                    }
                }


                //Mostramos mensaje
                if (tipoEncontrado)
                {
                    Console.WriteLine($"Todos los medicamentos de tipo {type} han sido destruidos.");
                }
                else
                {
                    Console.WriteLine($"No existen medicamentos de tipo {type}.");
                }
            }
        }


        //Autodestrucción
        public override void DestructionProcess()
        {

            //Variable a usar
            string op;

            //Pedimos una opcion
            Console.WriteLine("¡ATENCIÓN! Esta acción borrará todo el contenido en esta sucursal.");
            op = GetValidAnswer("¿Está seguro de que desea continuar? (Sí/No): ");

            //Mostramos mensaje segun op
            if (op == "si")
            {
                _medicamentos.Clear();
                Console.WriteLine("Todo el contenido de la sucursal ha sido eliminado.");
            }
            else
            {
                Console.WriteLine("No se ha borrado el contendio de la sucursal.");
            }
        }
    }
}