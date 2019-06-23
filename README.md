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
 
## Which auth mechanism did you use and why?

Rest services are authorized with tokens. According to my research; i can do with using jwt but i can't cultivate this part to develop
because of any experiment about it.

## How did you fix a “10 minute data update issue” without Windows Service?

When client search any movie, service firstly goes to database if data is found, control the record date then
if present time greater than the record time 10 minutes, old record is deleted from the database, is called rest service(omdb api) and  is inserted the new latest movie data to the database.

## Do you have any additional comments about this?

Using a timestamp on record to make them up to date is better than building a schedular system. Because it will increase the maintanence cost of project at total. 

## What would you like to do if you had more time?

I want to: 
* use redis for cache instead of default .Net caching.
* decorate the front-end part and provide more beautiful interface.
* do more refactoring code.
* develop login interface for authorization.
* use noSql database.
* container technology such as docker.

## Do you have additional comments?

This is a very comprehensive project that i spent much time and energy. It makes me to learn more new information and
apply that. It makes me very happy and thankful. I have learned dapper, restSharp, caching mechanism, Microsoft default dependency injection with this project and it was very enjoyable for me.Learning and applying new technologies make me excited.
I want to do my best but, my real performance is not this. I believe that can develop more qualified project without short time limits:)
Thank you.
