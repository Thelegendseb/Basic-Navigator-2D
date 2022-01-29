Module Module1

    ReadOnly NullBlock As String = "██"

    ReadOnly MapDimensionVal As Integer = 110 'has 2 be multiple of 2
    ReadOnly PlayerDimensionVal As Integer = 10 'has 2 be multiple of 2

    Structure BlockType
        Dim TOB As String
        Dim Design As String
        Dim Color As ConsoleColor
    End Structure
    Sub Main()

        Dim XPos As Integer = MapDimensionVal / 2
        Dim YPos As Integer = MapDimensionVal / 2
        Dim ColorForCompare As ConsoleColor


        Dim ColorArray4Test() As ConsoleColor = {ConsoleColor.Green,
                                                 ConsoleColor.Red,
                                                 ConsoleColor.White,
                                                 ConsoleColor.Blue,
                                                 ConsoleColor.DarkMagenta}


        Dim Map(,) As BlockType = FillMapTest(ColorArray4Test)
        'DisplayTest4Map(Map)
        Map(YPos, XPos - 5).Color = ConsoleColor.Black    'why oh why 

        Dim PlayerView(PlayerDimensionVal, PlayerDimensionVal) As BlockType

        Do
            Dim Input As ConsoleKeyInfo = Console.ReadKey()

            Select Case Input.KeyChar
                Case "s"
                    ColorForCompare = Map(YPos + 1, XPos).Color
                    If ColorForCompare <> ConsoleColor.DarkMagenta Then
                        YPos += 1
                    End If
                Case "d"
                    ColorForCompare = Map(YPos, XPos + 1).Color
                    If ColorForCompare <> ConsoleColor.DarkMagenta Then
                        XPos += 1
                    End If
                Case "w"
                    ColorForCompare = Map(YPos - 1, XPos).Color
                    If ColorForCompare <> ConsoleColor.DarkMagenta Then
                        YPos -= 1
                    End If
                Case "a"
                    ColorForCompare = Map(YPos, XPos - 1).Color
                    If ColorForCompare <> ConsoleColor.DarkMagenta Then
                        XPos -= 1
                    End If
            End Select


            For y = 0 To PlayerDimensionVal
                    For x = 0 To PlayerDimensionVal

                    PlayerView(y, x) = Map(y + YPos, x + XPos)

                Next
                Next
            PlayerView((PlayerDimensionVal / 2), (PlayerDimensionVal / 2)).Color = ConsoleColor.Black
            Console.SetCursorPosition(25, 6)
            Console.ForegroundColor = ConsoleColor.White
            Console.Write("(" & YPos & "," & XPos & ")")  'cord display
            Console.SetCursorPosition(0, 1)
            DisplayTest4Player(PlayerView)
            Console.SetCursorPosition(0, 0)


        Loop


        Console.ReadLine()

    End Sub

    Function FillMapTest(ColorArr() As ConsoleColor) As BlockType(,)

        Dim Rnd As New Random(5)  '5 is called a seed value
        Dim Map(MapDimensionVal, MapDimensionVal) As BlockType

        'Rnd.Next(ColorArr.Length)

        For y = 0 To MapDimensionVal
            For x = 0 To MapDimensionVal
                Dim Block As BlockType
                Block.TOB = "TestBlock"
                Block.Design = NullBlock
                Block.Color = ColorArr(Rnd.Next(ColorArr.Length))
                Map(y, x) = Block
            Next
        Next

        Return Map

    End Function

    'Sub DisplayTest4Map(Map(,) As BlockType)

    '    For y = 0 To MapDimensionVal
    '        For x = 0 To MapDimensionVal
    '            Console.ForegroundColor = Map(y, x).Color
    '            Console.Write(Map(y, x).Design)
    '        Next
    '        Console.WriteLine()
    '    Next

    'End Sub
    Sub DisplayTest4Player(PlayerView(,) As BlockType)

        For y = 0 To PlayerDimensionVal
            For x = 0 To PlayerDimensionVal
                Console.ForegroundColor = PlayerView(y, x).Color
                Console.Write(PlayerView(y, x).Design)
            Next
            Console.WriteLine()
        Next

    End Sub


End Module