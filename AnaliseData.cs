using System;
class AnaliseData {
  DateTime thisDay = DateTime.Today,
           timeUtc = DateTime.UtcNow;
  
  int diaI, horaI, minutosI, taskI;
  string dia = DateTime.Now.ToString("dd"),
         mes = DateTime.Now.ToString("MM"),
         ano = DateTime.Now.ToString("yyyy"),
         hora, minuto;
  System.TimeZoneInfo brasilia = TimeZoneInfo.FindSystemTimeZoneById("Brazil/East");
  public AnaliseData() {
    hora   = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, brasilia).ToString("HH");
    minuto = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, brasilia).ToString("mm");
  }

  public bool verificaValores( string diaA, string horaA, string minutosA, string taskA ) {
    int diaAI, horaAI, minutosAI;
    try{
      diaAI = int.Parse(diaA);
      Console.WriteLine($"{diaAI } < {int.Parse(dia)} = {diaAI > int.Parse(dia)}");
      if( diaAI < int.Parse(dia) ) {
        return false;
      }

    } catch {
      Console.WriteLine("Você digitou o dia erradamente!");
    }
    try{
      horaAI    = int.Parse(horaA);
      if( horaAI < 1 | horaAI > 24 ) {
        return false;
      }

    } catch {
      Console.WriteLine("Você digitou a hora erradamente!");
    }
    try{
      minutosAI = int.Parse(minutosA);
      if( minutosAI < 1 | minutosAI > 60 ){
        Console.WriteLine("Hora digitada errada");
        return false;
      }

    } catch {
      Console.WriteLine("Algum valor foi digitado errado, tente novamente!");
    }

    return true;
  }

  public bool analiseDiaPassou(string diaA, string horaA, string minutoA) {
    int diaAI = int.Parse(diaA), horaAI = int.Parse(horaA), minutoAI = int.Parse(minutoA);
    if( diaAI < int.Parse(dia) ) {
      return true;
    } else if ( diaAI <= int.Parse(dia) & horaAI < int.Parse(hora) ) {
      return true;
    } else if ( diaAI <= int.Parse(dia) & horaAI <= int.Parse(hora) & minutoAI < int.Parse(minuto) ) {
      return true;
    }
    return false;
  }

  public bool analiseEspera ( string diaA, string horaA, string minutoA, string taskA ) {
    thisDay = DateTime.Today;
    timeUtc = DateTime.UtcNow;
    System.TimeZoneInfo brasilia = TimeZoneInfo.FindSystemTimeZoneById("Brazil/East");
    hora   = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, brasilia).ToString("HH");
    minuto = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, brasilia).ToString("mm");
    // Console.WriteLine($"dia {dia} | hora {hora} | minuto {minuto}");
    int diaAI = int.Parse(diaA), horaAI = int.Parse(horaA), minutoAI = int.Parse(minutoA);
    if(diaAI==int.Parse(dia) & horaAI==int.Parse(hora) & minutoAI==int.Parse(minuto)) {
      Console.WriteLine(taskA);
      return true;
    }
    return false;
  }
  
}