# ASP.NET-Minimal-Api

- Sobre:

    - Desenvolvida para estudar a nova forma de criar API do .NET 6.
    - A API possui apenas uma classe e um CRUD.

- Classes:
    - Pessoa:
        ```
        {
            public long Id { get; set; }
            [Required, MaxLength(255)] public string Nome { get; set; } = "";
            public int Idade { get; set; }
            public string Sexo { get; set; } = "";
            public DateTime DataHoraCriacao { get; set; }
        }
        ```

- End Points:
    - Get (All):
        - http://localhost:5003/pessoa
            - Retorno:
                ```
                [
                    {
                        "id": 1,
                        "nome": "Brenno de Carvalho Prado Frangella Sciammarella",
                        "idade": 24,
                        "sexo": "Masculino",
                        "dataHoraCriacao": "2022-06-30T00:09:09.848626"
                    }
                ]
                ```
    - Get (Id):
        - http://localhost:5003/pessoa/1
            - Retorno:
                ```
                {
                    "id": 1,
                    "nome": "Brenno de Carvalho Prado Frangella Sciammarella",
                    "idade": 24,
                    "sexo": "Masculino",
                    "dataHoraCriacao": "2022-06-30T00:09:09.848626"
                }
                ```
    - Post:
        - http://localhost:5003/pessoa
            - Corpo:
                ```
                {
                    "Nome": "Brenno de Carvalho Prado Frangella Sciammarella",
                    "Idade": 24,
                    "Sexo": "Masculino"
                }
                ```
            - Retorno:
                ```
                {
                    "id": 1,
                    "nome": "Brenno de Carvalho Prado Frangella Sciammarella",
                    "idade": 24,
                    "sexo": "Masculino",
                    "dataHoraCriacao": "2022-06-30T00:09:09.848626"
                }
                ```
    - Put: 
        - http://localhost:5003/pessoa/1
            - Corpo:
                ```
                {
                    "Id": 1,
                    "Nome": "Brenno de C.P.F. Sciammarella",
                    "Idade": 24,
                    "Sexo": "Masculino"
                }
                ```
            - Retorno:
                ```
                Sem retorno
                ```
    - Delete:
        - http://localhost:5003/pessoa/1
            - Retorno:
                ```
                Sem retorno
                ```