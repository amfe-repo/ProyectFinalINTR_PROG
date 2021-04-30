using System;
using static System.Console;
using comp;
using System.Collections.Generic;

namespace ProjectFinal
{
    public class ProjectStructure
    {
        XmlConection xml_interface = new XmlConection();

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
                WriteLine("Ingresar cualquier valor para salir\n");

                Write("Selecion: ");
            
                try
                {
                    selection = int.Parse(ReadLine());

                    Clear();
                    switch (selection)
                    {
                        case 1:
                            createUserSection();
                            break;
                        case 2:
                            loginUserSecction();
                            break;    
                        default:
                            WriteLine("No ha seleccionado una opcion valida, el programa se cerrara");
                            loop_control = false;
                            break;
                    }
                }
                catch
                {
                    WriteLine("Error de datos!!");
                    loop_control = false;
                    ReadKey();  
                }
                

                Clear();
            }
        }

        private void createUserSection()
        {
            string name = "", pass = "";
            int money = 0;

            WriteLine("****Registro de usuario****\n");
            WriteLine("Ingrese sus datos personales:\n");

            Write("Nombre: ");
            name = ReadLine();

            Write("\nPass: ");
            pass = ReadLine();

            Write("\nMoney: ");
            money = int.Parse(ReadLine());

            try
            {
                User p1 = new User(xml_interface.generateId().ToString(), name, pass, money, 1);

                if (p1.verifyUserDB())
                {
                    WriteLine("\nEste nombre de usuario ya existe!!");
                    ReadKey();
                }
                else
                {
                    p1.addUserDB();
                    WriteLine("\nSe creo el usuario correctamente!!");
                    ReadKey();
                }
            }
            catch
            {
                WriteLine("Error al ingresar los datos!!");
            }
            
        }

        private void loginUserSecction()
        {
            string name = "", pass = "";

            Clear();

            WriteLine("****Inicio de sesion****\n");
            WriteLine("Ingrese sus datos personales:\n");

            Write("Nombre: ");
            name = ReadLine();

            Write("\nPass: ");
            pass = ReadLine();

            try
            {
                User p1 = new User("", name, pass, 0, 1);

                if (p1.verifyUserDB())
                {
                    mainCreateTable(name);
                }
                else
                {
                    WriteLine("\nEste nombre de usuario no existe!!");
                    ReadKey();
                }
            }
            catch
            {
                WriteLine("Error al ingresar los datos!!");
            }
        }

        private void mainCreateTable(string user)
        {
            int selection = 0;

            WriteLine($"****Bienvenido {user}****\n");
            WriteLine("Seleccione lo que desea hacer:\n");

            WriteLine("1. Tomar prestamos y crear tabla amortizada");
            WriteLine("2. Cambiar usuario\n");

            Write("Seleccion: ");

            try
            {
                selection = int.Parse(ReadLine());

                
                switch (selection)
                {
                    case 1:
                        createTablaAmort();
                        break;
                    case 2:
                        loginUserSecction();
                        break;
                    default:
                        WriteLine("No ha seleccionado una opcion valida, volvera a la primera pantalla");
                        break;
                }
            }
            catch
            {
                WriteLine("No ha seleccionado una opcion valida, volvera a la primera pantalla");
            }

            Clear();
        
        }

        private void createTablaAmort()
        {
            Clear();

            double fee = 0.0, interest = 0.0;
            int number_month = 0;

            WriteLine("Ingrese las informaciones solicitadas:\n");

            Write("Monto del prestamos: ");
            fee = double.Parse(ReadLine());

            Write("\nPorcentaje de tasa anual: ");
            interest = double.Parse(ReadLine());

            Write("\nPlazo en meses: ");
            number_month = int.Parse(ReadLine());

            Calculate cl = new Calculate(fee, number_month, interest);

            List<Amortization> amort = cl.createTable();
            
            WriteLine("\n***Tabla de amortizacion***\n");

            foreach (var item in amort)
            {
               WriteLine($"{item.id}: {(int)item.init_fee} -- {(int)item.fee} -- {(int)item.interest} -- {(int)item.stock} -- {(int)item.balance}"); 
            }
            
            WriteLine("\nPresione cualquier tecla");

            ReadKey();
        }
    }
}