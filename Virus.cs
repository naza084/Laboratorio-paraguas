namespace Laboratorio_paraguas
{
    internal class Virus : Medicamento
    {

        //Constructor
        public Virus(Designation designation)
        {
            //Asignamos propiedades
            _name = GenerateName();
            _id = GenerateID();
            _designation = designation;
        }

      

        //Metodos:


        //Generar nombre
        public string GenerateName()
        {

            //Creamos a randal
            Random randal = new();


            //Generamos letra
            char letra = (char)('a' + randal.Next(0, 26));


            //Retornamos name
            return string.Format("Vacuna {0}", letra);
        }


        //Generar identificador unico
        public override string GenerateID()
        {

            //Creamos a randal
            Random randal = new();


            //Creamos id
            int numID = randal.Next(1, 1000);


            //Retornamos id formateado
            return string.Format("VIR{0:000}", numID);
        }

    }
}
