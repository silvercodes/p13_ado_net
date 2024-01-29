



//async void MethodAsync()
//{
//    Console.WriteLine("Hello");
//    //
//    //
//    //
//    // await ....
//    //
//    //
//    // await ....
//    //
//    //
//    //
//}

//MethodAsync();


//// Возвращаемые типы
//// void             :-(((
//// Task
//// Task<T>
//// ValueTask<T>




#region Example_1

//using System.Text;

//Console.WriteLine("Start Main");

//ReadContentAsync("data.txt");


//Console.WriteLine("End Main");
//Console.ReadKey();


//async Task ReadContentAsync(string path)
//{
//    using FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);

//    byte[] buffer = new byte[1024];
//    await Task.Delay(5000);
//    await fs.ReadAsync(buffer, 0, buffer.Length);
//    Console.WriteLine(Encoding.UTF8.GetString(buffer));
//}



#endregion




#region Example_2

// Синхронный вызов
// Console.WriteLine(ReadSocket());


// Ожидание выполнения асинхронного метода
// string content = await ReadSocketAsync();


// Асинхронный вызов
RunAsync();
Console.WriteLine("End main");
Console.ReadKey();



string ReadSocket()
{
    Thread.Sleep(3000);

    return "Data from socket";
}


Task<string> ReadSocketAsync()
{
    return Task.Run(() => ReadSocket());
}


async Task RunAsync()
{
    string data = await ReadSocketAsync();

    Console.WriteLine($"Data = {data}");
}


#endregion