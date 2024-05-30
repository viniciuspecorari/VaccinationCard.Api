# Cartão Vacinal - Vinicius Pecorari
O objetivo deste sistema é permitir o gerenciamento das vacinações de um usuário. Para alcançar esse objetivo, foi desenvolvida uma API em C# que fornece diversos serviços para facilitar o registro, consulta e exclusão de informações relacionadas às vacinas administradas.

## Escopo
Na imagem abaixo temos as models utilizadas no projeto:
![Modelagem](https://drive.google.com/drive/folders/19j-wQNVeT6I5rWvHadyimeqYbGyOmWWb?usp=sharing)

### Suas relações são:
* Um usuário possui N vacinações e uma vacinação é feita em um usuário
* Uma vacinação é composta por uma dose de uma vacina
* Uma vacina pode ser aplicada em N vacinações
* Uma dose pode ser aplicada em N vacinações
