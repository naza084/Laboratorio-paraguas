namespace Laboratorio_paraguas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Escenario:
             La Corporación Paragüas, una empresa farmacéutica, necesita un programa para catalogar sus 
             nuevas vacunas experimentales.

             Flujo del Programa:

             Al ingresar al programa, se muestra una lista de códigos de 3 caracteres alfanuméricos de todas las sucursales en el sistema.

             El usuario tiene la opción de seleccionar una sucursal. Puede ingresar 
             "SALIR" en cualquier momento para salir del programa.

             Una vez dentro de una sucursal, el usuario puede elegir entre varias opciones:

             Catalogar nueva vacuna: Se puede crear una nueva vacuna con todos sus datos debidamente
             validados y se agrega a la lista de vacunas disponibles en la sucursal.

             Sintetizar virus: Si hay vacunas guardadas, el usuario puede elegir sintetizar un 
             virus derivado de la última vacuna. Se agrega una característica adicional al código 
             alfanumérico del virus.

             Destruir vacuna o virus: El usuario puede seleccionar un medicamento de la lista y 
             destruirlo. Si es una vacuna, su código se cambia a "XXX", y si es un virus, 
             su código se cambia a "YYYY".

             Destruir por tipo: El usuario elige un tipo de medicamento y procede a destruir todos 
             los medicamentos de ese tipo siguiendo el procedimiento del paso anterior.

             Activar sistema de autodestrucción: Esta opción borra todo el contenido de
             la sucursal activa.

             Activar sistema de autodestrucción global: Esta opción borra todas las sucursales 
             después de una confirmación del usuario.

             Salir: Permite al usuario volver al menú de selección de sucursal.

             Tipos de Medicamentos:
             Los medicamentos (vacunas y virus) deben tener un nombre, un 
             identificador único y una de las siguientes designaciones: ALFA,
             BETA, GAMA, EPSILON, OMEGA o TAU.
            poner uml al final xD
             */


            //Variables a usar
            int opSistema = 1;
            int opSucursal;


            //Instanciamos un Sistema
            Sistema sistema = new();


            //Instanciamos n sucursales
            Sucursal sucursal1 = new();
            Sucursal sucursal2 = new();
            Sucursal sucursal3 = new();


            //Añadimos n sucursales de forma silenciosa
            sistema.AddSucursal(sucursal1);
            sistema.AddSucursal(sucursal2);
            sistema.AddSucursal(sucursal3);


            //Damos la bienvenida 
            sistema.Welcome();


            //Iniciamos programa
            while (opSistema != 0)
            {

                //Mostramos la lista de sucursales
                sistema.DisplayBranches();
                Console.WriteLine();


                //Pedimos opcion, (0 para salir)
                opSistema = sistema.GetValidOption("Elija una sucursal (0 para salir): ");


                //Verificamos que no se digito un 7
                if (opSistema != 0)
                {

                    //Instanciamos una sucursal asignada segun op
                    Sucursal sucursalN = sistema._sucursals[opSistema - 1];


                    //Damos la bienvenida a la sucursal correspondiente
                    sucursalN.Welcome();


                    //Trabajamos de la sucursal
                    do
                    {

                        //Mostramos el menu de opciones de la sucursal
                        sucursalN.DisplayMenu();


                        //Pedimos una opcion
                        opSucursal = sucursalN.GetValidOption("Elija una opción: ");


                        //Ejecutamos la opcíon
                        sucursalN.ExecuteOption(opSucursal, sistema);


                    } while (opSucursal != 7);


                    //En caso de que se decida volver al menu de sucursales
                    Console.WriteLine("Ha vuelto al menú de selección de sucursal.");
                    Console.WriteLine();
                }
            }


            //nos despedimos con un goodbye
            Console.Clear();
            sistema.GoodBye();


            Console.ReadKey();

        }
    }
}