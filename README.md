# A simple MVC web application

The main use of the project is to demonstrate some best practices regarding software development implementation details.

## Design Patterns implemented

### 1. Factory Method Pattern

**usage:** better encapsulate the object creation logic, the creation logic is abstracted away from the controller

**particular usecase:** in this project the Factory Method pattern is utilized to create instances of `Employee` objects with varying constructor arguments.

### 2. Decorator Pattern

**usage:** adding behavior to individual objects dynamically, without affecting the behavior of other objects from the same class

**particular usecase:** in this project the Decorator pattern is used to add logging functionality to repository operations without modifying the core repository classes.
