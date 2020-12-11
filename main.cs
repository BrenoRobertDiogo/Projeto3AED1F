// Agenda automática
using System;
using System.Globalization;
class MainClass {
  public static void Main () {
    Console.Clear();

    Console.WriteLine("Bem vindo ao seu assistente virtual de horarios\n=====INSTRUÇÕES======\nEle só registra os dados do mês ATUAL, a funcionalidade de ");
    AgendarDia agendamentos = new AgendarDia();
    int continuar = 0;
    string dia, hora, minutos, task;
    
    var brasilia = TimeZoneInfo.FindSystemTimeZoneById("Brazil/East");
    DateTime timeUtc = DateTime.UtcNow;
    do{
      Console.Write("[1] Adicionar task | [2] Fechar programa | [3] Aguardar tarefas | [4] Tarefas a fazer\n~ ");
      // Caso a pessoa digite uma string
      try {
        continuar = int.Parse(Console.ReadLine());
      } catch {
        continuar = 0;
      }
      
      if ( continuar < 0 | continuar > 4 ) 
        throw new ArgumentNullException("Deve ser digitado 's' ou 'n'");

      switch( continuar ) {
        case 1: //Adicionar task
          Console.Write("Digite o dia : ");
          dia  = Console.ReadLine();
          Console.Write("Digite a hora: ");
          hora = Console.ReadLine();
          Console.Write("Digite os minutos: ");
          minutos = Console.ReadLine();
          Console.Write("Digite a task: ");
          task = Console.ReadLine();

          agendamentos.EscreveArquivo(dia, hora, minutos, task);
          break;

        case 3: //Aguardar tarefas
          agendamentos.esperaValores();
          break;

        case 4: //Tarefas a fazer
          agendamentos.lerArquivo();
          break;
        
        case 0: // Caso digite algo errado
          Console.WriteLine("Digitou algo errado hein amigão :)");
          break;

        default:
          break;
      }

    } while( continuar != 2 );

  }
}