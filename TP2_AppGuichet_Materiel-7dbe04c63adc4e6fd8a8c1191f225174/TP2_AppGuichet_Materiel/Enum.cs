namespace AppGuichet
{
    /// ============================================================
    /// <summary>
    /// Énumération des sortes de comptes possibles pour un client.
    /// </summary>
    /// --------------------------------------------------------------------
    public enum Roles { Administrateur, Client };
    /// ====================================================================
    /// ============================================================
    /// <summary>
    /// Énumération des sortes de comptes possibles pour un client.
    /// </summary>
    /// --------------------------------------------------------------------
    public enum SorteComptes { Aucun = -1, Épargne, Chèque ,Intérêt };
    /// ====================================================================


    /// ===================================================================
    /// <summary>
    /// Énumération des sortes de transactions possibles sur le guichet.
    /// </summary>
    /// ------------------------------------------------------------------
    public enum SorteTransactions { Dépôt, Retrait };
    /// ==================================================================
    /// 

    /// ===================================================================
    /// <summary>
    /// Énumération des filtres d'opération.
    /// </summary>
    /// ------------------------------------------------------------------
    public enum FiltreOperation { Toutes, Dépôt, Retrait };

}