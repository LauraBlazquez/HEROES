namespace Constants
{
    public class Messages
    {
        //Menú inicio
        public const string Welcome = "\n¡¡Bienvenido a AdventureQuest!!\n";
        public const string Menu = "¿Qué desea hacer ahora mi señor?\n1. Iniciar una nueva aventura\n0. Salir";
        public const string Bye = "\nGracias por jugar, espero pronto su regreso mi señor.";
        public const string MsgErrorOption = "\nLa opción que ha introducido no aparece en el menú mi señor, deme otra opción:";
        public const string MsgErrorMenu = "\nHa introducido 3 veces un valor no válido, reinicie el juego.";

        //Menú dificultad
        public const string ChooseDificulty = "\n¿Con qué dificultad quiere jugar?\n\n1. Fácil\n2. Difícil\n3. Personalizado\n4. Random";

        //Asignación nombres
        public const string NamesMsg = "\nComo quiere llamar a sus heroes, mi señor?\n\nIntroduzca 4 nombres separados por comas: (Arquera,Bárbaro,Maga,Druida)";
        public const string NamesError = "\nHa de introducir 4 nombres mi señor, vuelva a provar:";

        //Asignación valores usuario
        public const string Health = "\n¿Qué valor le quiere poner a la vida de {0}? [{1},{2}]";
        public const string Attack = "\n¿Qué valor le quiere poner al ataque de {0}? [{1},{2}]";
        public const string Shield = "\n¿Qué valor le quiere poner al escudo de {0}? [{1},{2}]";
        public const string InvalidValue = "\nHa introducido un valor fuera del rango permitido, vuelva a provar:";

        //Batalla
        public const string Begin = "\n\n¡¡QUE EMPIECE LA BATALLA!!\n";
        public const string SkipTutorial = "\nTutorial de la batalla:\n¿Quiere leerlo, mi señor? Pulse y, sinó pulse ENTER";
        public const string Tutorial = "\nEsta batalla se basa en un sistema de turnos. En cada turno de nuestros guerreros ha de escoger entre 3 opciones, atacar, zafarse o utilizar la habilidad especial del guerrero. Esta se recargará después de 5 turnos. \nTambién tendrá que escoger la acción del Monstruo entre atacar o zafarse. Su misión es acabar con el monstruo, no importa que solo quede un héroe en pie, mi señor, honrará la memoria de sus compañeros caídos. \n\nAhora sí, ¡¡QUE EMPIECE LA BATALLA!!\n\n\n(Se recomiendo abrir la consola con pantalla completa para una mejor experiencia)";
        public const string Action = "\n¿Qué quiere que haga {0}, mi señor?\n1. Atacar\n2. Zafarse\n3. Usar Habilidad especial\n";
        public const string MonsterAction = "\nEl monstruo ataca a {0} inflingiendole un {1} de daño.";
        public const string SleepyMonster = "\nEl monstruo no atacará esta ronda...";
        public const string MonsterDamage = "\n{0} ha inflingido {1} de daño al Monstruo.";
        public const string ShieldImprove = "\n{0} aumenta su escudo a un {1} %";
        public const string UseHability = "\n{0} usa su habilidad especial.";
        public const string HabilityUn = "\nAun no se puede usar la habilidad especial mi señor. (Turnos restantes {0})";
        public const string ErrorBattleOption = "\nHa introducido una opcion incorrecta 3 veces, se salta el turno...";
        public const string Critical = "\n¡¡El ataque ha dado en el blanco!! Le ha hecho un ataque crítico al Monstruo provocando {0} de daño.";
        public const string AttackFailed = "\nEl ataque ha fallado... Más suerte la próxima vez.";
        public const string Win = "\n¡¡HA GANADO MI SEÑOR!!";
        public const string Defeat = "\nTodos nuestros heroes han caído en la batalla...";


        public const string Archer = @"
               .
         .MMMM |\         {0}
        /( ¬_¬)|_\_       Vida: {1}
        |/ |===| /        Ataque: {2}
        '  |   |/         Escudo: {3} %
          / \  '          Habilidad: Nockea al monstruo durante 2 turnos.";
        public const string Barbarian = @"
                 .^.   	 
        .~~~-_   | |      {0}	 	  
        ~( ¬_¬)  | |      Vida: {1}
         --|--- ""-_-""     Ataque: {2}
           |      !       Escudo: {3} %
          / \             Habilidad: Aumenta su escudo al 100% durante 3 turnos.";
        public const string Magician = @"
         -_'_           
        _'____'_          {0}
        /( ¬_¬) * *       Vida: {1}
        |/ |=== (O)*      Ataque: {2}
        '  |    * *       Escudo: {3} %
          / \             Habilidad: Inflinge 3 ataques de daño al monstruo.";
        public const string Druid = @"
         -_'_     
        _'____'(O)        {0}
         ( ¬_¬)=|=        Vida: {1}
         --|--- |         Ataque: {2}
           |    |         Escudo: {3} %
          / \   |         Habilidad: Cura 500 puntos de vida a sus compañeros.";
        public const string Monster = @"
                                                                      _.-{{-,_
                                                                     /\  {   /\
                                                                    (0\\_ _//0)|_
                                                                     (__''__)  \|_          
                                                                      WVVVVW    \/|_        
                                                                     _\MMMM/     /_ /       
                                                                   _/ ;---' _     /_/|_
                                                                  /   \   _/      \/_ /   /\
                                                                  VVV'|  /   /     \/_    ) \
                                                                      \ VVV'      )._/_.,-'  )
                                                                      (_   \ (_   \         /
                                                                     (VVV__/(VVV__/''--····'";
        public const string MonsterStats = @"
                                                                                                Vida: {0}
                                                                                                Ataque: {1}
                                                                                                Escudo: {2} %";
        public const string DeadWarrior = @"
           |
        ===+===
           |
           |
           |
           |";
        public const string DeadMonster = @"
                                                                               |
                                                                               |
                                                                               |
                                                                               |
                                                                       ========+========
                                                                               |
                                                                               |
                                                                               |
                                                                               |
                                                                               |
                                                                               |
                                                                               |
                                                                               |";

    }

    public class Values
    {
        public const int Archer = 0, Barbarian = 1, Magician = 2, Druid = 3;
        public const int Health = 1, Attack = 2, Shield = 3, Hability = 4;
        public const int ArcherHealthMin = 1500, ArcherAttackMin = 200, ArcherShieldMin = 25;
        public const int ArcherHealthMax = 2000, ArcherAttackMax = 300, ArcherShieldMax = 35;
        public const int BarbarianHealthMin = 3000, BarbarianAttackMin = 150, BarbarianShieldMin = 35;
        public const int BarbarianHealthMax = 3750, BarbarianAttackMax = 250, BarbarianShieldMax = 45;
        public const int MagicianHealthMin = 1100, MagicianAttackMin = 300, MagicianShieldMin = 20;
        public const int MagicianHealthMax = 1500, MagicianAttackMax = 400, MagicianShieldMax = 35;
        public const int DruidHealthMin = 2000, DruidAttackMin = 70, DruidShieldMin = 25;
        public const int DruidHealthMax = 2500, DruidAttackMax = 120, DruidShieldMax = 40;
        public const int MonsterHealthMin = 7000, MonsterAttackMin = 300, MonsterShieldMin = 20;
        public const int MonsterHealthMax = 10000, MonsterAttackMax = 400, MonsterShieldMax = 30;
        public const int Cooldown = 5, KnockOut = 2, MegaShield = 100, Enchant = 500;

        public const int NecessaryLength = 4;
        public const int Attemps = 3;
        public const int Op0 = 0, Op1 = 1, Op3 = 3, Op4 = 4;
        public const int Percent = 100;
        public const int Double = 2;
        public const int Critical = 10;
        public const int AttackFail = 5;
    }
}