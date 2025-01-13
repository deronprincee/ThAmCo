# ThAmCo

ThAmCo is a console app designed for the event staff to manage bookings for different events and their venues, as well as manage the catering.


#Key problems and solutions

There was a syntax error in "ThAmCo.Events" due to which the Razor pages were unable to update the database with the new information added on the page. The problem was fixed by adding an annotation in each class, "[Validate Never]" above the table links.
