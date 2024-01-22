 namespace trainee.Models;
 using System.ComponentModel.DataAnnotations;

 public class TraineeModel
   {
       [Key]
       public string? Employeeid  { get; set; }
       public string EmployeeName { get; set; } = null!;
       public decimal EmployeeSalary { get; set; }
       public string EmployeeDesignation { get; set; } = null!;
       public string EmployeeFathername { get; set; } = null!;
   }
