namespace Laboratorio_paraguas
{
    internal class Vacuna : Medicamento
    {

        //Propiedades
        private bool _virusSintetizado;



        //Constructor
        public Vacuna()
        {
            //Asignamos propiedades
            _name = GetValidName("Nombre de la nueva vacuna: ");
            _id = GenerateID();
            Console.WriteLine("Identificador unico: ", _id);
            _designation = GetValidDesignation();
            _virusSintetizado = false;
        }




        //Metodos:


        //Generar identificador unico
        public override string GenerateID()
        {
            //Creamos a randal
            Random randal = new();


            //Creamos id
            int numID = randal.Next(1, 1000);


            //Retornamos id formateado
            return string.Format("VAC{0:000}", numID);
        }


        //Obtener estado 
        public bool GetEstado() { return _virusSintetizado; }

        //Establecer estado
        public void SetEstado(bool valor)
        {
            _virusSintetizado = valor;
        }
    }
}
