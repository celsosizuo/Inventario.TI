**Proximos passos:**
	- /*Criar criptografia para o campo senha (para gravar e verificar) - OK em 22/12/2023*/
	- Deixar multi-empresa com 1 banco de dados;
	- Implementar log na aplica��o;
	Pensar nas classes do sistema


ativa��o de conta:
- Efetua o cadastro;
- Recebe e-mail com a confirma��o do cadastro e a ativa��o;
- Ao clicar no link � feita a ativa��o da conta;

Esqueci minha senha:
- Recebe e-mail como par�metro de pesquisa e restaura��o da senha;
- Tenta localizar o caadastro pelo e-mail;
- Se achar envia um token por e-mail;
- Usu�rio valida o token;
- Token v�lido, faz o reset de senha;

