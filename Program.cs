// See https://aka.ms/new-console-template for more information
string mensagemDeBoasVindas = "Bem vindo ao Screen Sound";
List<string> listaDasBandas = new List<string>{"U2", "The Beatles", "The Killers"};

void ExibirLogo() {
    Console.WriteLine(@"
╭━━━╮╱╱╱╱╱╱╱╱╱╱╱╱╱╱╭━━━╮╱╱╱╱╱╱╱╱╱╱╭╮
┃╭━╮┃╱╱╱╱╱╱╱╱╱╱╱╱╱╱┃╭━╮┃╱╱╱╱╱╱╱╱╱╱┃┃
┃╰━━┳━━┳━┳━━┳━━┳━╮╱┃╰━━┳━━┳╮╭┳━╮╭━╯┃
╰━━╮┃╭━┫╭┫┃━┫┃━┫╭╮╮╰━━╮┃╭╮┃┃┃┃╭╮┫╭╮┃
┃╰━╯┃╰━┫┃┃┃━┫┃━┫┃┃┃┃╰━╯┃╰╯┃╰╯┃┃┃┃╰╯┃
╰━━━┻━━┻╯╰━━┻━━┻╯╰╯╰━━━┻━━┻━━┻╯╰┻━━╯
    ");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu(){
    ExibirLogo();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica){
        case 1: RegistrarBandas();
            break;
        case 2: ExibirListaDasBandas();
            break;
        case 3: Console.WriteLine($"Voce escolheu a opcao {opcaoEscolhidaNumerica}");
            break;
        case 4: Console.WriteLine($"Voce escolheu a opcao {opcaoEscolhidaNumerica}");
            break;
        case -1: Console.WriteLine($"Voce escolheu a opcao {opcaoEscolhidaNumerica}. Saindo...");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBandas(){
    Console.Clear();
    Console.WriteLine("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Boolean bandaEncontrada = false;
    foreach(string item in listaDasBandas)
    {
        if(nomeDaBanda == item){
            bandaEncontrada = true;
        }
    }
    
    if(!bandaEncontrada){
        listaDasBandas.Add(nomeDaBanda);
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    } else {
        Console.WriteLine($"Banda {nomeDaBanda} já registra.");
    }
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirListaDasBandas(){
    Console.Clear();
    Console.WriteLine("Bandas Registradas: ");
    foreach(string element in listaDasBandas){
        Console.WriteLine(element);
    }
    Console.WriteLine("Pressione uma tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

ExibirOpcoesDoMenu();