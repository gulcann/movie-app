# movie-app

Client can search any movie and get latest update info about it.

## Which patterns did you use and why did you choose those patterns?

### Repository Pattern

I used repository pattern to manage data access layer of my api project.
I chosed this pattern because:
* it is very convenient for managing data from a single point
* Prevents code duplication,
* Present a loosely coupled structure. For example; i use dapper micro orm and Sql Server database in this project but 
i can use another orm tool instead of dapper or another noSql database instead of sql. This makes my project's layer independent to each other.
* Consequently; it provides easy maintanance.
This pattern provide developer to draw central structure for data processing and queries to avoid repetition.
In program, the actual work of the sections and data access section seperating from each other by repository pattern.

### Dependency Injection Pattern

I used dependency injection in my project so that classes with different responsibilities have a relationship on 
loosely coupled. I injected dependency through the constructor that provide me to achive loosely coupled relationship and 
agree with the Liskov Substitution Principle. For example; if I would create my MovieRepository and MovieSource classes inside the class 
instead of injection through the constructor, i had made tightly coupled relationship between class, this made this dependency hard to change. This effects the maintanance in a bad way.
      
## Which DI tools did you use and why did you choose that tool?

 I used Microsoft default dependency injection library.It is easy to use and enought for this project.

