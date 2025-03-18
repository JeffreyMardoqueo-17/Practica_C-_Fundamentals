using System;
using System.Text.RegularExpressions;

class InputService{
    public string GetInput(string message){ 
        Console.WriteLine(message);
        return Console.ReadLine();
    }
}

// Clase de validación con nombre corregido
class ValidateData{
    public bool ValidateName(string name){
        return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
    }

    public bool ValidateAge(int age){
        return age >= 18 && age <= 150;
    }    
}

class UserDataService{
    private readonly InputService _inputService;
    private readonly ValidateData _validateData;

    // Constructor corregido con inyección de ValidateData
    public UserDataService(InputService inputService, ValidateData validateData){
        _inputService = inputService;
        _validateData = validateData;
    }

    public string GetName(){
        while(true){
            try{
                string name = _inputService.GetInput("Ingrese su nombre:");
                if(_validateData.ValidateName(name))
                    return name;
                Console.WriteLine("El nombre no debe estar vacío y solo puede contener letras.");
            }catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    
    public int GetAge(){
        while(true){
            try{
                if(int.TryParse(_inputService.GetInput("Ingrese su edad"), out int age) && _validateData.ValidateAge(age)){
                    return age;
                }
                Console.WriteLine("La edad debe estar entre 18 y 150 años. Inténtelo de nuevo.");
            }catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public decimal GetSalary(){
        while(true){
            try{
                if(decimal.TryParse(_inputService.GetInput("Ingrese su salario"), out decimal salary)){
                    return salary;
                }
                Console.WriteLine("Salario inválido. Inténtelo de nuevo.");
            }catch(Exception ex){
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

class Program{
    static void Main(){
        InputService inputService = new InputService();
        ValidateData validateData = new ValidateData();
        UserDataService userDataService = new UserDataService(inputService, validateData);

        string name = userDataService.GetName();
        int age = userDataService.GetAge();
        decimal salary = userDataService.GetSalary();

        Console.WriteLine($"Hola {name}, tienes {age} años de edad y estás ganando ${salary}. ¡Wooow!");
    }
}
