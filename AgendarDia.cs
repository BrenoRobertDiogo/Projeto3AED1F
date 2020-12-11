using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;//declarando a biblioteca IO para que seja
                //utilizado arquivos externos
                //no caso o arquivo txt.
class AgendarDia {
  StreamReader Arquivo;
  string localArquivo;
  public string LocalArquivo { get{return localArquivo;} set{localArquivo = value;} }

  List<string[]> listaTarefas;
  public List<string[]> ListaTarefas   { get{return listaTarefas;} set{listaTarefas = value;} }

  AnaliseData analiseData = new AnaliseData();

  public AgendarDia(  ) { 
    localArquivo = "agenda.txt";
  }
  public AgendarDia( string diretorio ) {
    localArquivo = diretorio;
  }

  public void atualizaValoresTabela(  ) {
    listaTarefas =  new List<string[]>();
    Arquivo = File.OpenText(LocalArquivo);
    while (Arquivo.EndOfStream != true) {
      //le conteúdo da linha
      string linha = Arquivo.ReadLine();

      listaTarefas.Add(linha.Split(","));
    }
    Arquivo.Close();  
  }

  public void lerArquivo (  ) {
    bool analiseTrueOrFalse = false;
    atualizaValoresTabela(  );
    Console.WriteLine($"| DIA| |HORÁRIO | TASK | Status da tarefa");
    foreach( var a in listaTarefas) {
        for(int i=0; i<a.Count(); i++) {
          switch (i) {
            case 1:
              Console.Write($"| {a[i]}:{a[i+1]}  ");
              break;
            case 2:
              break;
            default:
              Console.Write($"| {a[i]} | ");
              break;
          }
          analiseTrueOrFalse = analiseData.analiseDiaPassou( a[0], a[1], a[2] );
          
        }
        if( analiseTrueOrFalse ) {
            Console.Write("💹");
          } else{
            Console.Write("⛔");
          }
        Console.WriteLine("");
      }

  }

  public void esperaValores (  ) {
    atualizaValoresTabela(  );
    bool resultado = false;

    while(!resultado) {
      foreach(var i in listaTarefas) {
       resultado = analiseData.analiseEspera(i[0], i[1], i[2], i[3]);
     }
    }
    
  }

  public void EscreveArquivo(string dia, string hora, string minutos, string task) {
    StreamWriter Arquivo;
    Arquivo = File.AppendText(LocalArquivo);
    if(!analiseData.verificaValores(dia, hora, minutos, task)) {
      Console.WriteLine("Você digitou algum valor inválido, favor digitar novamente essa task");
    } else {
      Arquivo.WriteLine($"{dia},{hora},{minutos},{task}" ); // DIA, HORA, TASK, MINUTOS
      Arquivo.Close();
    }
    
  }
}