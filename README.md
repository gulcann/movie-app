# movie-app

Client can search any movie and get latest update info about it.

* Which patterns did you use and why did you choose those patterns?
* Which DI tools did you use and why did you choose that tool?
* Which auth mechanism did you use and why?
* How did you fix a “10 minute data update issue” without Windows Service?
* Do you have any additional comments about this?
* What would you like to do if you had more time?
* Do you have additional comments?

## Which patterns did you use and why did you choose those patterns?

### Repository Pattern

I used this pattern to my project's ASP.NET web api part to do data transactions (get,insert,delete).
I chosed this pattern because:
* it is very convenient for managing data from a single point
* Prevents code duplication,
* Makes it easy to catch bugs,
* Makes it easy to code writing, reading, testing,
* At the end; it provides easy maintanance.
This pattern provide developer to draw central structure for data processing and queries to avoid repetition.
In program, the actual work of the sections and data access section seperating from each other by repository pattern.

### Dependency Injection Pattern

I used dependency injection on constructor so that classes with different responsibilities have a relationship on 
loosely coupled.I injected dependency through the constructor that provide me to achive loosely couple relationship and 
agree with the Liskov Substitution Principle. 
      
## Which DI tools did you use and why did you choose that tool?

I used Microsoft default dependency injection library.It is easy to use.
-
-
-
## Which auth mechanism did you use and why?
-
-
-
-
-
## How did you fix a “10 minute data update issue” without Windows Service?
Data firstly searched from the database
