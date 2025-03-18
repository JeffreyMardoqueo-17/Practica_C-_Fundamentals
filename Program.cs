using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


class InputService{
    public string GetInput(string Message){ 
        Console.WriteLine(Message);
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
        return Console.ReadLine();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
    }
}

class UserDataService{
    private readonly InputService _inputService ;
    
    public UserDataService(InputService inputService){
        _inputService = inputService ;
    }

    public string GetName(){
        while(true){
            try{
                string name = _inputService.GetInput("Enter your name:");
                if(!string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                    return name ;
                Console.Write("El nombre no debe de estar vacio");
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
    
    public int GetAge(){
        
        while(true){
            try{
                if(int.TryParse(_inputService.GetInput("Ingrese su edad"), out int age))
                return age;
                    Console.WriteLine("Edad invalidad. Intentelo de nuevo");
                }catch(Exception ex){
                    Console.Write($"Hay un error {ex}");
            }
        }
    }

public decimal GetSalary(){
    while(true){
        try{
            if(decimal.TryParse(_inputService.GetInput("Ingrese su salario"), out decimal salary))
                return salary;
                Console.WriteLine("Salario invalido. Intentelo de nuevo");
        }catch(Exception ex){
            Console.Write($"Hay un error {ex}");
        }
    }
}
}

class Program{
    static void Main(){
        InputService inputService = new InputService();
        UserDataService userDataService = new UserDataService(inputService);

        string name = userDataService.GetName();
        int age = userDataService.GetAge();
        decimal salary = userDataService.GetSalary();

        Console.WriteLine($"Hola {name} , tienes {age} años de edad y estas ganando ${salary}. wooo");
    }
}