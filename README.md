# Apex-Remington_Demo
I have provided two solutions to this assignment. Both solutions use Linq to SQL as the persistence framework. The first solution is purley
C# ASP.NET and the second uses as well as Jquery and KnockOut.js. Both solutions make use of the same view. On the DemoView.aspx there are
five controls:
Two: text input fileds which accept a start and end due date. A date can be manually entered into the fields or selected from
a Jquery UI date picker control. The fields are validated on the blur event and are checked to see if the date entered is in the format
MM/dd/yyyy and that it is a valid date (i.e. 03/32/2018 will not pass muster).

Three Buttons: Titled ASP.NET, KnockOut, and Export. Both buttons render the same 15 row table by differnet means. Should a date
be passed where the year is greater than 2014 an alert will be generated informing the user that order dates do not exceed 2014.
If the date is valid the ASP.NET solution makes use of a repository class, a model class, and a grid view control. The JQuery/KnockOut 
solution makes an ajax call to an asp.net webservice which uses the same repository and model as the first soltuion. The results of the 
query are then serialized as a JSON string and sent back to the client. The JSON returned, parsed and is then used to construct a viewmodel consiting 
of a KnockOut observable array and bound to an html table.

The Export button generates the excel spread sheet saves it to a virtual temp directory and transmits it to the user's session; providing 
a prompt to open or save the file. The file is deleted from the temp directory after the transfer.
