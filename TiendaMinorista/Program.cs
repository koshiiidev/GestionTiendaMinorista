using System;
using System.Collections.Generic;

using TiendaMinorista;
//Ing. Isaac Lopez V
//Examen Parcial I
//Gestion de Tienda Minorista
try
{
    //Inicializacion del sistema
    Console.WriteLine("==== Iniciando el sitema de gestion de Tienda ====\n");
    var sistema = new SistemaGestion();


    Console.WriteLine("1. Probando gestion de productos e inventario...");
    //Productos de prueba
    var leche = new ProductoPerecible("P001", "Leche", 1000,100, DateTime.Now.AddDays(30));
    var arroz = new ProductoNoPerecible("P002", "Arroz", 1000, 200, "Alimentos");

    var inventarioFiel = typeof(SistemaGestion).GetField("inventario", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    var inventario = (List<Producto>)inventarioFiel.GetValue(sistema);
    inventario.Add(leche);
    inventario.Add(arroz);

    //Verificacion del inventario
    Console.WriteLine($"Producto: {leche.Nombre}, Stock: {leche.CantidadInventario}");
    Console.WriteLine($"Producto: {arroz.Nombre}, Stock: {arroz.CantidadInventario}");
    Console.WriteLine("Gestion de productos completada con exito. \n");


    //Prueba de gestion de clientes
    Console.WriteLine("2. Probando gestion de clientes...");

    //Crear clientes
    var cliente = new Cliente("C001", "Isaac Lopez", "saaclv27@gmail.com");
    var cliente2 = new Cliente("C002", "Mon Rubi", "monchis@gmail.com");

    var clientesField = typeof(SistemaGestion).GetField("clientes", System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance);
    var clientes = (List<Cliente>)clientesField.GetValue(sistema);
    clientes.Add(cliente);
    clientes.Add(cliente2);

    Console.WriteLine($"Cliente creado: {cliente.Nombre} (ID: {cliente.Id})");
    Console.WriteLine($"Cliente creado: {cliente2.Nombre} (ID: {cliente2.Id})");
    Console.WriteLine("Gestion de clientes completada con exito. \n");

    //Prueba de registro de ventas
    Console.WriteLine("3. Probando registro de ventas...");

    //creacion de una venta

    var productosYCantidades = new Dictionary<string, int>
    {
        {"P001", 2 }, {"P002", 3}
    };

    sistema.RegistrarVenta("V001", "C001", productosYCantidades);
    Console.WriteLine("Venta registrada con exito");

    //verificar si se actualizo el stock en el inventario
    Console.WriteLine($"Stoc actualizado de {leche.Nombre}: {leche.CantidadInventario}");
    Console.WriteLine($"Stoc actualizado de {arroz.Nombre}: {arroz.CantidadInventario}");
    Console.WriteLine("Registro de ventas completado con exito. \n");

    //Prueba del sistema de envios
    Console.WriteLine("4. Probando sistema de envios...");

    //creacion de un envio
    var envioTerrestre = new EnvioTerrestre("E001", "Isaac Lopez", "Calle Principal 321", "CAM011");
    var envioAereo = new EnvioAereo("E002", "Isaac Lopez", "San Jose", "VUELO001", 5.5);

    //registrar envios
    Console.WriteLine("\n Mostrando detalles de todos los envios:");
    sistema.MostrarTodosLosEnvios();

    //5. Prueba de expeciones

    try 
    {
        var ventaInvalida = new Dictionary<string, int>
        {
            {"P001", 1000 } //se intenta vender mas de lo disponible
        };
        sistema.RegistrarVenta("V002", "C002", ventaInvalida);

    }
    catch (ProductoNoDisponibleException e)
    {
        Console.WriteLine($"Error controlado correctamente: {e.Message}");
    }

    //intentar buscar un producto que no existe
    try
    {
        sistema.BuscarProducto("P003");

    }
    catch (ProductoNoExisteException e)
    {
        Console.WriteLine($"Error controlado correctamente: {e.Message}");
    }

    Console.WriteLine("\n==== Pruebas completadas con exito ;) ====");

}
catch (Exception e)
{
    Console.WriteLine($"\n Error inesperado: {e.Message}");
    Console.WriteLine($"\n StackTrace: {e.StackTrace}");

}