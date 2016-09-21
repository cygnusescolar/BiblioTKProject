Public Module FuncionesGenerales

    ''' <summary>
    ''' Funcion para tomar la hora central de México. 
    ''' </summary>
    ''' <returns>hora central de mexico</returns>
    Public Function UtcToMexCentral() As Date
        Return UtcToMexCentral(Date.Now.ToUniversalTime())
    End Function

    ''' <summary>
    ''' Funcion para tomar la hora central de México. 
    ''' </summary>
    ''' <param name="universalTime"></param>
    ''' <returns>hora central de mexico</returns>
    Public Function UtcToMexCentral(universalTime As Date) As Date
        Dim timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)")
        Return TimeZoneInfo.ConvertTimeFromUtc(universalTime, timeZone)
    End Function

End Module

