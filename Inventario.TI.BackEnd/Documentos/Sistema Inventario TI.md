**Proximos passos:**
	- /*Criar criptografia para o campo senha (para gravar e verificar) - OK em 22/12/2023*/
	- Deixar multi-empresa com 1 banco de dados;
	- Implementar log na aplicação;
	Pensar nas classes do sistema


ativação de conta:
- Efetua o cadastro;
- Recebe e-mail com a confirmação do cadastro e a ativação;
- Ao clicar no link é feita a ativação da conta;

Esqueci minha senha:
- Recebe e-mail como parâmetro de pesquisa e restauração da senha;
- Tenta localizar o caadastro pelo e-mail;
- Se achar envia um token por e-mail;
- Usuário valida o token;
- Token válido, faz o reset de senha;

