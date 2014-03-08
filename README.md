Break-SqlEntityConnection
=========================

Breaking SqlEntityConnection with Simple.Web and F#

This repository goes hand-in-hand with this blog post: http://thwadi.blogspot.com/2014/03/combining-f-and-simpleweb-to-break.html

Create a database (I called mine "BlowItUp") and run the Create.sql script in '/SQL Scripts'.
Be sure to edit the script to use the correct database, of course. Next, change the web.config to
point to your database. I used LocalDB for this repro, but experienced the issue against a full
SQL Server installation as well.

Next, load the solution and run it in debug. The page that loads will make an AJAX call to
trigger the handler (Home.fs) which will catch the exception and write it out to Trace. If you have
any questions, open an issue or let me know on Twitter (@jjvdangelo). Thanks!
