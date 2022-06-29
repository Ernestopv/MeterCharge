# MeterCharge


System description

We have 3 kind of meters, electricity, water and Heat, that measures consumption in some unit, They measure in different units, but the specific kind of unit
is not important here so we use the abstraction unit.

- Electricity cost 4 per unit . But half price between 20:00 and 8:00
- Water cost 3 per unit.
- Heat cost 5 per unit.
The charge is calculated: [Charge = Cost * Consumption].

The systems has been created by a consultant, and it will currently persist meter readings (charge, cost and
consumption) to a file for each meter.

-------

## Assigment description

1- Refactor the MeterChargeSaver class.
- Decouple the file persistence mechanism, so that another type of persistence (such as a database) can
  be injected in the future. Please provide at least one persistence implementation such as text file.
  
- Try to rewrite the code that calculates the cost in a neater way so that the number of “if” statements
are reduced or eliminated if possible.
- Refactor MeterChargeSaver class to make it SOLID compliant.

2- The core code that perform the cost calculations should be written using TDD
- Mock or stub dependencies as you like.

3- Feel free to create as many new classes, interfaces or change anything else in the code if you need to.

## Solution
Not only the MeterChargeSaver class has been refactored making it SOLID compliant, 
but the whole project has also split into libraries with the following design:

- MeterCharge (The core of the application)
- MeterCharge.DataAccess ( Handles the data db or textFile)
- MeterCharge.DataAccess.Tests ( Handles the unit tests of the libary MeterCharge.DataAccess)
- MeterCharge.Infrastructure ( Handles app.config and File)
- MeterCharge.Models ( Handles the models )
- MeterCharge.Schema (Handles the  dto schema)
- MeterCharge.Tests (Handles the unit tests of the core application)

![image](https://user-images.githubusercontent.com/24325283/175838336-8d0e3e37-9094-43a1-9b2d-09a2cf527a66.png)

The file persistence mechanism as been decoupled with the implementation of the factory pattern, now there is flexibility in picking another way 
of handling data, by setting enableDb to true from app.config;

![image](https://user-images.githubusercontent.com/24325283/175839174-01658eec-9bda-4507-9bf0-05fb3e2e5089.png)


The application will store the MeterReaderConsumption to the database(Meters) all records in one table called dbo.MeterReader **;

![image](https://user-images.githubusercontent.com/24325283/175839437-3811cf24-e0a2-463f-845d-0472d6902536.png)

Otherwise will store the data to a file for each meter;

![image](https://user-images.githubusercontent.com/24325283/175839358-18865c64-1d9f-4a4a-ac81-b805360017a6.png)




Also with the implementation of the factory pattern the "if" statements have been reduced from the principal class (MeterChargeSaver.cs),
when the "MeterType.Electricity" is set as an identifier the  Electricity class is going to be instanciated to calculate the electricity consumption, 
the same applies to water("MeterType.Water") and heating("MeterType.Heating").

![image](https://user-images.githubusercontent.com/24325283/175838834-cc789594-65ea-41d1-b63f-15a2f783a5b4.png)


 The core code  that perform the cost calculations was written using TDD on the following project library:
 - MeterCharge.Tests,  a few dependecies were mocked using the nuget library NSubstitute
 
![image](https://user-images.githubusercontent.com/24325283/176563983-f9cf2901-a604-4721-80c3-517f89395630.png)

 
The configuration like connectionString, is being handled on app.Config 
from the core Project (MeterCharge).

![image](https://user-images.githubusercontent.com/24325283/175841056-87816472-2ce6-46cc-acca-a54cb7ee7c94.png)


##### ** Bonuses
 <sub>- Added persistence mechanism DB using entity framework ,- Github actions implemented  see workflow : https://github.com/Ernestopv/MeterCharge/actions


 <sub>.Net Framework 4.7.2 </sub>
  






