# Plano de Testes de Software

## Plano de testes

Os planos de teste serão realizados de acordo com as funcionalidades e controle de acesso. A realização dos testes apresentará um score cuja classificação é apresentada na tabela abaixo:


### A. Testes de controle de acesso:


|Score|Ação                           |Exemplo                                                                                                   |
|-----|-------------------------------|----------------------------------------------------------------------------------------------------------|
|0	   |A ação testada apresentou problemas críticos que inviabilizam a plataforma.|A plataforma apresenta um _looping_ infinito no cadastro de novos dados.|
|1    |A ação testada apresentou problemas graves que podem gerar problemas a plataforma.|A plataforma apresenta um tempo muito grande para realizar busca em um banco de dados.|
|2    |A ação testada problemas leves que possui uma probabilidade baixa de apresentar danos a plataforma|O usuário não faz o login automático ao realizar o cadastro.|
|3    |A ação testada não apresentou erros aparentes|-|

Os testes de seguirão os planos de acordo com suas classificações:

|Caso de Teste | CT-01 Cadastro de usuários |
|--------------|-------------------------------------------------------------------------|
|Requisitos atendidos | RF-008:O site deverá fornecer um formulário de cadastro. |
|Objetivos do Teste   |Verificar o fluxo de cadastro de novos usuários na plataforma por meio de novos cadastros, login de usuários já cadastrados e o seu logout.|
|Passos               |1: Acesso da plataforma;<br>2: Realizar o cadastro do usuário. |
|Critérios de êxito   |1: Acesso do usuário a plataforma via login<br>2: Comunicação com o banco de dados de forma estável;<br>3: Validação dos campos do formulário de cadastro<br>|



|Caso de Teste        |CT-02- Login de usuários     |
|---------------------|----------------------------------------------------------------|                   
|Requesitos atendidos |RF - 008:O site deverá fornecer um formulário de cadastro para Pessoa Física Pessoa Jurídica. 
|Objetivos do Teste   |Verificar o fluxo de acesso dos usuários a plataforma.|
|Passos               |1: Realizar login com usuário;<br>1:	Acessar a área de usuário; <br>2: Realizar alterações nos dados;<br>3:	Verificar se as alterações foram validadas;<br>4:	Fazer logout;<br>5:	Verificar se o usuário não possui mais acesso a área restrita;<br>6:	Realizar login com usuário ;<br> 7:	Acessar a área de clientes;<br>8: Realizar alterações nos dados docliente; <br>9: Verificar se o usuário não possui mais acesso a área restrita;|
|Critérios de êxito   |1: Realizar o login e ter acesso a área restrita de usuário;<br>2:	Permitir o acesso e alterações de campos dos usuários validados;<br>3:Restringir o acesso a área restrita de usuários não permitidos (não logados)|



|Caso de Teste        |CT-03- Cadastro de novos usuários na plataforma|
|---------------------|----------------------------------------------------------------|
|Requesitos atendidos |RF-005 O site deverá conter um sistema de Cadastro de Clientes, com informações referente ao serviço prestado.  
|Objetivos do Teste   |Verificar o fluxo de cadastro de novos usuários na plataforma por meio de novos cadastros, edição de usuários já cadastrados e sua remoção. 
|Passos               |1: Acesso da plataforma;<br>2: Realizar o cadastro do usuário; relizar a remoção do usuário cadastrado;
|Critérios de êxito   |1: Acesso do usuário a plataforma via login<br>2: Comunicação com o banco de dados de forma estável;<br>3: Validação dos campos do  cadastro<br>|
