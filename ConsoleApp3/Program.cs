using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        Console.WriteLine("Bienvenido a mi lista de Contactes");


        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        bool runing = true;


        while (runing)
        {
            Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
            Console.WriteLine("Digite el número de la opción deseada: ");

            int typeOption;
            if (!int.TryParse(Console.ReadLine(), out typeOption))
            {
                Console.WriteLine("Por favor digite un número válido.");
                continue;
            }

            switch (typeOption)
            {
                case 1: // Agregar contacto
                    {
                        Console.WriteLine("Digite el nombre de la persona");
                        string name = Console.ReadLine();

                        Console.WriteLine("Digite el apellido de la persona");
                        string lastname = Console.ReadLine();

                        Console.WriteLine("Digite la dirección");
                        string address = Console.ReadLine();

                        Console.WriteLine("Digite el telefono de la persona");
                        string phone = Console.ReadLine();

                        Console.WriteLine("Digite el email de la persona");
                        string email = Console.ReadLine();

                        Console.WriteLine("Digite la edad de la persona en números");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Especifique con un numero si es mejor amigo donde #1 es si y #2 es No.. solo insertar el numero");
                        int temp = Convert.ToInt32(Console.ReadLine());
                        bool isBestFriend = false;

                        if (temp == 1)
                        {
                            isBestFriend = true;
                        }
                        else
                        {
                            isBestFriend = false;
                        }

                        int id = ids.Count + 1;

                        ids.Add(id);
                        names.Add(id, name);
                        lastnames.Add(id, lastname);
                        addresses.Add(id, address);
                        telephones.Add(id, phone);
                        emails.Add(id, email);
                        ages.Add(id, age);
                        bestFriends.Add(id, isBestFriend);

                        Console.WriteLine("Contacto agregado correctamente.");
                        break;

                    }
                case 2: //ver contactos
                    {
                        Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                        Console.WriteLine($"____________________________________________________________________________________________________________________________");

                        if (ids.Count == 0)
                        {
                            Console.WriteLine("No hay contactos registrados.");
                            break;
                        }

                        foreach (var id in ids)
                        {
                            bool isBestFriend = bestFriends[id];

                            string isBestFriendStr;

                            if (isBestFriend == true)
                            {
                                isBestFriendStr = "Si";
                            }
                            else
                            {
                                isBestFriendStr = "No";
                            }

                            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                        }
                    }
                    break;

                case 3: //buscar contactos
                    {
                        Console.WriteLine("Insertar el nombre o parte del nombre del contacto que desea buscar: ");
                        string searchTerm = Console.ReadLine().ToLower();

                        bool found = false;

                        Console.WriteLine(" Nombre               Apellido               Dirección              Teléfono               Email                 Edad         Es Mejor Amigo?");
                        Console.WriteLine("________________________________________________________________________________________________________________________________________________");

                        foreach (var id in ids)
                        {
                            if (names[id].ToLower().Contains(searchTerm))
                            {
                                found = true;

                                string isBestFriendStr = bestFriends[id] ? "Si" : "No";

                                Console.WriteLine($" {names[id]}          {lastnames[id]}          {addresses[id]}          {telephones[id]}          {emails[id]}          {ages[id]}          {isBestFriendStr}");
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
                        }

                        break;
                    }


                case 4: //modificar
                    {
                        Console.WriteLine("Digite el nombre o parte del nombre del contacto que desea modificar: ");
                        string searchTerm = Console.ReadLine().ToLower();

                        int foundId = -1;

                        foreach (var id in ids)
                        {
                            if (names[id].ToLower().Contains(searchTerm))
                            {
                                foundId = id;
                                Console.WriteLine($"Contacto encontrado: {names[id]} {lastnames[id]}");
                                break;
                            }
                        }
                        if (foundId == -1)
                        {
                            Console.WriteLine("No se encontro ningun contacto con ese nombre.");
                            break;
                        }

                        Console.WriteLine("Que desea modificar?");
                        Console.WriteLine("1.Nombre ");
                        Console.WriteLine("2.Apellido");
                        Console.WriteLine("3.Direccion");
                        Console.WriteLine("4. Telefono");
                        Console.WriteLine("5. Email");
                        Console.WriteLine("6. Edad");
                        Console.WriteLine("7.Mejor amigo(si/no)");

                        int option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Nuevo nombre:");
                                names[foundId] = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Nuevo apellido:");
                                lastnames[foundId] = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Nueva dirección:");
                                addresses[foundId] = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("Nuevo teléfono:");
                                telephones[foundId] = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Nuevo email:");
                                emails[foundId] = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Nueva edad:");
                                ages[foundId] = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 7:
                                Console.WriteLine("¿Es mejor amigo? 1. Sí  2. No");
                                bestFriends[foundId] = Convert.ToInt32(Console.ReadLine()) == 1;
                                break;
                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }

                        Console.WriteLine("Contacto modificado correctamente.");
                        break;
                    }

                case 5: // Eliminar contacto
                    {
                        Console.WriteLine("Digite el nombre del contacto que desea eliminar:");
                        string nameToDelete = Console.ReadLine();

                        int foundId = -1;

                        //En este case puede ser con el ID
                        foreach (var id in ids)
                        {
                            if (names[id].ToLower() == nameToDelete.ToLower())
                            {
                                foundId = id;
                                break;
                            }
                        }

                        // Si encontramos el contacto
                        if (foundId != -1)
                        {
                            Console.WriteLine($"¿Seguro que desea eliminar a {names[foundId]}? (1 = Sí, 2 = No)");
                            int confirm = Convert.ToInt32(Console.ReadLine());

                            if (confirm == 1)
                            {
                                // Eliminamos el contacto de todas las colecciones
                                ids.Remove(foundId);
                                names.Remove(foundId);
                                lastnames.Remove(foundId);
                                addresses.Remove(foundId);
                                telephones.Remove(foundId);
                                emails.Remove(foundId);
                                ages.Remove(foundId);
                                bestFriends.Remove(foundId);

                                Console.WriteLine("✅ Contacto eliminado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("Operación cancelada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("❌ No se encontró ningún contacto con ese nombre.");
                        }

                        break;
                    }
                case 6: // Salir del programa
                    {
                        Console.WriteLine("Saliendo del programa... ¡Hasta luego!");
                        runing = false; // Cambia la condición del while para detener el ciclo
                        break;
                    }
            }
        }
    }

    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en números");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);
    }
}
