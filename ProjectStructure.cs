using System;
using static System.Console;
using comp;

namespace ProjectFinal
{
    public class ProjectStructure
    {
        public void init()
        {   
            bool loop_control = true;
            int selection = 0;

            while(loop_control)
            {
                Clear();

                WriteLine("Bienvenido al sistema de banco nacional");
                WriteLine("\nSeleccione la opcion que desea ejecutar:\n");
                WriteLine("1. Crear nuevo usuario");
                WriteLine("2. Ingresar usuario existente\n");

                Write("Selecion: ");
                selection = int.Parse(ReadLine());

                switch (selection)
                {
                    case 1:
                        Clear();
                        createUserSection();
                        break;
                    case 2:
                        //Al ingresar el usuario se llevara a la amortizacion
                        break;    
                    default:
                        WriteLine("No ha seleccionado una opcion valida, el programa se cerrara");
                        loop_control = false;
                        break;
                }

                Clear();
            }
        }

        private void createUserSection()
        {
            string name = "", pass = "";
            int money = 0;

            XmlConection xml_interface = new XmlConection();  
        
            WriteLine("Ingrese sus datos personales: ");

            Write("Nombre: ");
            name = ReadLine();

            Write("\nPass: ");
            pass = ReadLine();

            Write("\nMoney: ");
            money = int.Parse(ReadLine());

            //Crear script que compruebe si el usuario existe

            try
            {
                User p1 = new User(xml_interface.generateId().ToString(), name, pass, money, 1);
                p1.addUserDB();
            }
            catch
            {
                WriteLine("Error al ingresar los datos!!");
            }
            

        }

    }
}