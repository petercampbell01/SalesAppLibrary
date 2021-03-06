﻿<html>
    <body>
        <h1>Sales App Library</h1>
        <p>This library is designed to provide basic functionality to a sales checkout programe as might be used in a supermarket or selfscanning service.</p>
        <h2>Architecture and Data flow</h2>
        <p>The key model of this project is the Product, Cart and Controller classes. Which are then connected to a Scanner and a View via the Controller. The library encompasses the entire basic structure of an MVC application to simplify system understanding and implementation. The controller is added as a DataReceiver for the scanner. When a product is scanned the data is fed direct to the Controller which then uses the DBHandler to search the database and then constructs a product instance using the data from the database. In the case of this library, data from a database is mimicked using an array. In a real world implementation this requires an implementation of the IDBHandler interface which would use for example SQL queries or LINQ to access a relational database. The design could be applied to any database type.</p>
        <p>The controller then sends the product to the cart where it is added and item counts and price costs are calculated. When an item is added to the Cart. The costs including bulk discounts are calculated and sent to the controller where they are sent direct to the view. In a web app this data would be sent in JSON or XML format to update the webpage immediately of the current cart status.</p>
        <p>Conceptually an unusual element in this design is that the item count and the total item cost are included in the product model. This is done to avoid running counts through arrays and when I was designing the system I thought might make it easier to implement but may lead to maintenance issues.</p>
        <h2>Projects</h2>
        <p>The solution is broken into two projects. One is the model described above. The other is UnitTests-Product which is a series of unit tests, testing the main functionality of the library. </p>
        <footer>
            <p>Readme.md and library written on 22/03/2020.</p>
        </footer>
    </body>
</html>
