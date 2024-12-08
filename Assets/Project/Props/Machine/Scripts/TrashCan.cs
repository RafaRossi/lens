using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : ExchangeItemBehaviour, IItemInteraction
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform objectHolderPoint;

    private GameObject currentObject = null;
    
    public Action OnItemDestroyed = delegate {  };

    public override bool? Interact(Interactor interactor)
    {
        if (base.Interact(interactor) == true)
        {
            ThrowTrash(interactor.GetCurrentEquippedItem.GetItem());
            
            return true;
        }

        return null;
    }

    private void ThrowTrash(UsableItem item)
    {
        currentObject = Instantiate(item.EquipablePrefab.gameObject, objectHolderPoint);

        animator.SetTrigger("Throw");
    }

    public void DestroyCurrentObject()
    {
        if (!currentObject) return;
        
        Destroy(currentObject);
            
        OnItemDestroyed?.Invoke();
    }
}

///o QUE VOCE ESTA FAZENDO AQUI?
/// dESCULPA, NÃO QUIS TE ASSUSSTAR, MAS VC NAO LEU A PLACA LÁ FORA?
/// NÃO ENTRE AQUI, ESTAVA ESCRITO EM VERMELHO E TALS
/// ENFIM, ESSA SESSAO AINDA ESTA EM MANUTENÇÃO, ENTAO SE PUDER POR GENTILEZA VOLTAR PELA PORTA QUE VOCE ENTROU E SEGUIR SEU CAMINHO NORMALMENTE.
///
///
/// OK, EU NÃO ESTAVA ESPERANDO PELA PORTA TRANCAR SOZINHA, VC N ESTARIA COM A CHAVE AI NÉ. É EU JÁ ESPERAVA QUE NÃO. HUM... TA JÁ SEI, TEM OUTRO CAMINHO
///
/// POR AQUI, POR ESSA PORTA.
///
/// DESCULPE, AINDA NÃO, MELHOR NÃO CORRER O RISCO DE DEIXAR VOCÊ SEGUIR SEU RUMO SOZINHO, VÁ QUE TENHA MAIS PLACAS POR AI QUE VOCÊ DECIDA DESOBEDECER.
/// AQUI, PUXE A ALAVANCA DESSA MAQUINA, VOU ME MATERIALIZAR EM UMA FORMA QUE VOCÊ POSSA ME LEVAR CONTIGO
///
/// O QUE FOI? MUITO ASSUSTADOR? SE ESSA FORMA FAZ VOCE SE SENTIR DESCONFORTÁVEL, POSSO ME MATERIALIZAR EM OUTRO OBJETO MAIS AMIGAVÉL,
/// SÓ ME DESCARTE ALI NO LIXO E PUXE A ALAVANCA NOVAMENTE, MAS SE ESTIVER DISPOSTO A ENFRENTAR SEUS MEDO PODEMOS SÓ SEGUIR NOSSO RUMO
///
/// SURPRESSA! FELIZ ANIVERSÁRIO! GOSTOU? VOCE CAIU DIREITINHO APOSTO Q N ESTAVA ESPERANDO "PUXA VIDA, UM BOLO DE ANIVERSARIO, Q INESPERADO
/// OBVIAMENTE O BOLO É DE MENTIRA, MAS O QUE VALE É INTENÇÃO, ENFIM. ESPERO QUE TENHA GOSTADO DA SURPRESA
/// QUANDO TERMINAR DE APROVEITAR SUA FESTA VOCÊ PODE SÓ FECHAR O JOGO MESMO.
