"use strict";
// Base Class
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    // Getter
    getSalary() {
        return this.salary;
    }
    // Setter with validation
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Invalid salary");
        }
    }
    // Method
    displayDetails() {
        console.log("Employee Details:");
        console.log("Id: " + this.id);
        console.log("Name: " + this.name);
        console.log("Salary: " + this.salary);
        console.log("----------------------");
    }
}
// Derived Class
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary); // call parent constructor
        this.teamSize = teamSize;
    }
    // Method Overriding
    displayDetails() {
        console.log("Manager Details:");
        console.log("Id: " + this.id);
        console.log("Name: " + this.name);
        console.log("Salary: " + this.getSalary()); // access via getter
        console.log("Team Size: " + this.teamSize);
        console.log("----------------------");
    }
}
// Object Creation
let emp1 = new Employee(1, "Anji", 25000);
let mgr1 = new Manager(2, "Lavi", 50000, 5);
// Using methods
emp1.displayDetails();
emp1.setSalary(30000);
console.log("Updated Salary:", emp1.getSalary());
mgr1.displayDetails();
