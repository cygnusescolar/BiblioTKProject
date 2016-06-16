Public Module FuncionesGenerales

    ''' <summary>
    ''' Funcion para tomar la hora central de mexico
    ''' </summary>
    ''' <returns>hora central de mexico</returns>
    Public Function Takoma_UTCToMexCentral() As DateTime
        Dim FechaUTC As DateTime = Now.ToUniversalTime
        Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)")
        Dim cstTime As DateTime = TimeZoneInfo.ConvertTimeFromUtc(FechaUTC, cstZone)
        Return cstTime
    End Function

    ''' <summary>
    ''' sobrecarga 
    ''' </summary>
    ''' <param name="vUTCDateTime"></param>
    ''' <returns>hora central de mexico</returns>
    Public Function Takoma_UTCToMexCentral(vUTCDateTime As DateTime) As DateTime
        Dim FechaUTC As DateTime = vUTCDateTime
        Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)")
        Dim cstTime As DateTime = TimeZoneInfo.ConvertTimeFromUtc(FechaUTC, cstZone)
        Return cstTime
    End Function

End Module

