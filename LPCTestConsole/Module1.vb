Module Module1

    Sub Main()
        Dim name As String
        Console.Title = "LABS Experimental Console (en)"
        Console.WriteLine("Enter your name")
        name = Console.ReadLine
        Console.Title = "LABS Experimental Console (en) - " + name + "'s session"
        Console.Write("Hello " + name + ", Welcome to the LABS Experimental console! Type 'help' to get started.")
        Console.WriteLine()
        com()

    End Sub
    Sub com()
        Dim command
        command = Console.ReadLine
        If command = "test" Then
            Console.WriteLine("It's a test command. Nothing to see.")
            'Console.Read()
        ElseIf command = "ver" Then
            Console.WriteLine("Version 1.1.rel (c) 2019 LPC")
            'Console.Read()
        ElseIf command = "help" Then
            Console.WriteLine("--------------HELP--------------")
            Console.WriteLine("Commands :")
            Console.WriteLine("clear : Clear the console")
            Console.WriteLine("cl : Clear the console")
            Console.WriteLine("help : get command info")
            Console.WriteLine("about : show the about page in the console")
            Console.WriteLine("ver : get the Console version")
            Console.WriteLine("home : Show the welcome message")
            Console.WriteLine("test : test command")
            Console.WriteLine("--------------------------------")
        ElseIf command = "about" Then
            Console.WriteLine("This an expiremental console for test-only.")
            Console.WriteLine("The language is VB")
            Console.WriteLine("Built with Visual Studio 2019")
            Console.WriteLine("You can see the version with using the 'ver' command.")
        ElseIf command = "clear" Then
            Console.Clear()
        ElseIf command = "cl" Then
            Console.Clear()
        ElseIf command = "home" Then
            Console.WriteLine("Hello, Welcome to the LPC Experimental console!")
        Else
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Unknown command. Type 'help' for more info.")
            Console.ForegroundColor = ConsoleColor.Gray
        End If
        'Console.Read()
        com()
    End Sub
End Module
