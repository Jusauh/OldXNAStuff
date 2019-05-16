using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


//Tässä luokassa alustetaan kaikki meidän pelin asseststit, kuvat äänet yms.

namespace TowerDefence.Engine
{
    class Assests
    {
        //Fontteja, numero tarkottaa kokoa
        public static SpriteFont Font10;
        public static SpriteFont Font14;
        public static SpriteFont Font24;
        public static SpriteFont Font32;
        public static SpriteFont Font40;
        public static SpriteFont Font48;
        public static SpriteFont Font96;
        //Kuvat
        public static Texture2D mainMenu; //OOOOOOOOOOOOOOOOOOOOOOOOOOO
        public static Texture2D optionsScreen; //OOOOOOOOOOOOOOOOOOOOOOOOOOO
        public static Texture2D masterVolume;
        public static Texture2D musicVolume;
        public static Texture2D sfxVolume;
        public static Texture2D plus;
        public static Texture2D pxl;
        //Buttons
        public static Texture2D playButton;
        public static Texture2D exitButton;
        public static Texture2D exitToMainMenuButton;
        public static Texture2D optionsButton;
        public static Texture2D backButton;
        public static Texture2D menuButton;
        public static Texture2D soundOn;
        public static Texture2D soundOff;
        public static Texture2D minus;
        public static Texture2D slider;
        public static Texture2D upgradeButton;
        public static Texture2D resumeButton; //OOOOOOOOOOOOOOOOOOOOOO
        public static Texture2D nextWaveButton;
        //Tornit
        public static Texture2D knightTower;
        public static Texture2D archerTower;
        public static Texture2D wizardTower;
        //Viholliset
        public static Texture2D goblinEnemy;
        public static Texture2D orcEnemy;
        public static Texture2D bossEnemy;
        //kartat
        public static Texture2D mapBeta;
        public static Texture2D map01;
        public static Texture2D map02;
        //Misc
        public static Texture2D cursor;
        public static Texture2D gridCursor;
        public static Texture2D hud;
        public static Texture2D rangeIndicator;
        public static Texture2D fireBall;
        //Partikkeli
        public static Texture2D particle;
        //Musiikit
        public static Song music01;
        public static Song music02;
        public static Song music03;
        public static Song music04;
        //Ääniefektit
        public static SoundEffect soundEffect01; 
        //Ritar äs
        public static SoundEffect knightSummon01;
        public static SoundEffect knightSummon02;
        public static SoundEffect knightSummon03;
        public static SoundEffect knightSummon04;
        public static SoundEffect knightSummon05;
        public static SoundEffect knightUpgrade01;
        public static SoundEffect knightUpgrade02;
        public static SoundEffect knightUpgrade03;
        //Wizardi
        public static SoundEffect wizardSummon01;
        public static SoundEffect wizardSummon02;
        public static SoundEffect wizardSummon03;
        public static SoundEffect wizardSummon04;
        public static SoundEffect wizardSummon05;
        public static SoundEffect wizardUpgrade01;
        public static SoundEffect wizardUpgrade02;
        public static SoundEffect wizardUpgrade03;
        //Archeri
        public static SoundEffect archerSummon01;
        public static SoundEffect archerSummon02;
        public static SoundEffect archerSummon03;
        public static SoundEffect archerSummon04;
        public static SoundEffect archerSummon05;
        public static SoundEffect archerUpgrade01;
        public static SoundEffect archerUpgrade02;
        public static SoundEffect archerUpgrade03;
        //goblin
        public static SoundEffect goblinDeath01;
        public static SoundEffect goblinDeath02;
        public static SoundEffect goblinDeath03;
        public static SoundEffect goblinDeath04;
        public static SoundEffect goblinDeath05;
        //orc
        public static SoundEffect orcDeath01;
        public static SoundEffect orcDeath02;
        public static SoundEffect orcDeath03;
        public static SoundEffect orcDeath04;
        public static SoundEffect orcDeath05;
        //boss 1
        public static SoundEffect bossSummon01;
        public static SoundEffect bossDefeat01;
        public static SoundEffect bossVictorious01;
        /// <summary>
        /// Tätä kutsumalla alustataan assestit
        /// </summary>
        /// <param name="content"></param>
        public static void LoadAssests(ContentManager content)
        {
            //Fontteja
            Font10 = content.Load<SpriteFont>("Fonts/BuxtonSketch10");
            Font14 = content.Load<SpriteFont>("Fonts/BuxtonSketch14");
            Font24 = content.Load<SpriteFont>("Fonts/BuxtonSketch24");
            Font32 = content.Load<SpriteFont>("Fonts/BuxtonSketch32");
            Font40 = content.Load<SpriteFont>("Fonts/BuxtonSketch40");
            Font48 = content.Load<SpriteFont>("Fonts/BuxtonSketch48");
            Font96 = content.Load<SpriteFont>("Fonts/BuxtonSketch96");
            //Kuvat
            mainMenu = content.Load<Texture2D>("UI/menu"); //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            optionsScreen = content.Load<Texture2D>("UI/options"); //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            masterVolume = content.Load<Texture2D>("MasterVolume");
            musicVolume = content.Load<Texture2D>("MusicVolume");
            sfxVolume = content.Load<Texture2D>("SFXVolume");
            slider = content.Load<Texture2D>("Slider");
            //Buttons
            playButton = content.Load<Texture2D>("Buttons/PlayButton");
            exitButton = content.Load<Texture2D>("Buttons/ExitButton");
            optionsButton = content.Load<Texture2D>("Buttons/OptionsButton");
            backButton = content.Load<Texture2D>("Buttons/BackButton");
            menuButton = content.Load<Texture2D>("Buttons/MenuButton");
            plus = content.Load<Texture2D>("Buttons/Plus");
            minus = content.Load<Texture2D>("Buttons/Minus");
            soundOn = content.Load<Texture2D>("Buttons/SoundOn");
            soundOff = content.Load<Texture2D>("Buttons/SoundOff");
            upgradeButton = content.Load<Texture2D>("Buttons/UpgradeButton");
            resumeButton = content.Load<Texture2D>("Buttons/ResumeButton"); //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
            nextWaveButton = content.Load<Texture2D>("Buttons/NextWaveButton");
            pxl = content.Load<Texture2D>("pxl");
            //buildArcherButton = content.Load<Texture2D>("Buttons/ResumeButton");
            //buildKnightButton = content.Load<Texture2D>("Buttons/ResumeButton");
            //buildWizardButton = content.Load<Texture2D>("Buttons/ResumeButton");
            //Tornit
            knightTower = content.Load<Texture2D>("Towers/knightfinal");
            archerTower = content.Load<Texture2D>("Towers/archerfinal");
            wizardTower = content.Load<Texture2D>("Towers/velhofinal");
            //Viholliset
            goblinEnemy = content.Load<Texture2D>("Enemies/goblinmockup");
            orcEnemy = content.Load<Texture2D>("Enemies/orc");
            bossEnemy = content.Load<Texture2D>("Enemies/theBoss");
            //kartat
            mapBeta = content.Load<Texture2D>("Maps/mapBeta");
            map01 = content.Load<Texture2D>("Maps/level1");
            map02 = content.Load<Texture2D>("Maps/level2");

            cursor = content.Load<Texture2D>("UI/Cursor");
            gridCursor = content.Load<Texture2D>("UI/gridCursor");
            hud = content.Load<Texture2D>("UI/hudParanneltu");
            rangeIndicator = content.Load<Texture2D>("UI/rangeIndicator");
            fireBall = content.Load<Texture2D>("FX/fireBall");
            //Partikkelit
            particle = content.Load<Texture2D>("FX/Particle_animation");
            //Musiikit
            music01 = content.Load<Song>("Music/01 - Strange Numbers");
            music02 = content.Load<Song>("Music/02 - Mischief");
            music03 = content.Load<Song>("Music/03 - H.A.M");
            music04 = content.Load<Song>("Music/04 - Gone");
            //Ääniefektit
            soundEffect01 = content.Load<SoundEffect>("SFX/01 - Toygun"); 
            //Ritari
            knightSummon01 = content.Load<SoundEffect>("SFX/Knight/Knight_Summon_1");
            knightSummon02 = content.Load<SoundEffect>("SFX/Knight/Knight_Summon_2");
            knightSummon03 = content.Load<SoundEffect>("SFX/Knight/Knight_Summon_3");
            knightSummon04 = content.Load<SoundEffect>("SFX/Knight/Knight_Summon_4");
            knightSummon05 = content.Load<SoundEffect>("SFX/Knight/Knight_Summon_5");
            knightUpgrade01 = content.Load<SoundEffect>("SFX/Knight/Knight_Upgrade_1");
            knightUpgrade02 = content.Load<SoundEffect>("SFX/Knight/Knight_Upgrade_2");
            knightUpgrade03 = content.Load<SoundEffect>("SFX/Knight/Knight_Upgrade_3");
            //Wizardi
            wizardSummon01 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Summon_1");
            wizardSummon02 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Summon_2");
            wizardSummon03 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Summon_3");
            wizardSummon04 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Summon_4");
            wizardSummon05 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Summon_5");
            wizardUpgrade01 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Upgrade_1");
            wizardUpgrade02 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Upgrade_2");
            wizardUpgrade03 = content.Load<SoundEffect>("SFX/Wizard/Wizard_Upgrade_3");
            //Archeri
            archerSummon01 = content.Load<SoundEffect>("SFX/Archer/Ranger_Summon_1");
            archerSummon02 = content.Load<SoundEffect>("SFX/Archer/Ranger_Summon_2");
            archerSummon03 = content.Load<SoundEffect>("SFX/Archer/Ranger_Summon_3");
            archerSummon04 = content.Load<SoundEffect>("SFX/Archer/Ranger_Summon_4");
            archerSummon05 = content.Load<SoundEffect>("SFX/Archer/Ranger_Summon_5");
            archerUpgrade01 = content.Load<SoundEffect>("SFX/Archer/Ranger_Upgrade_1");
            archerUpgrade02 = content.Load<SoundEffect>("SFX/Archer/Ranger_Upgrade_2");
            archerUpgrade03 = content.Load<SoundEffect>("SFX/Archer/Ranger_Upgrade_3");
            //Goblin
            goblinDeath01 = content.Load<SoundEffect>("SFX/Goblin/Goblin_Death_1");
            goblinDeath02 = content.Load<SoundEffect>("SFX/Goblin/Goblin_Death_2");
            goblinDeath03 = content.Load<SoundEffect>("SFX/Goblin/Goblin_Death_3");
            goblinDeath04 = content.Load<SoundEffect>("SFX/Goblin/Goblin_Death_4");
            goblinDeath05 = content.Load<SoundEffect>("SFX/Goblin/Goblin_Death_5");
            //Orc
            orcDeath01 = content.Load<SoundEffect>("SFX/Orc/Orc_Death_1");
            orcDeath02 = content.Load<SoundEffect>("SFX/Orc/Orc_Death_2");
            orcDeath03 = content.Load<SoundEffect>("SFX/Orc/Orc_Death_3");
            orcDeath04 = content.Load<SoundEffect>("SFX/Orc/Orc_Death_4");
            orcDeath05 = content.Load<SoundEffect>("SFX/Orc/Orc_Death_5");
            //Boss 1
            bossDefeat01 = content.Load<SoundEffect>("SFX/Boss 1/Boss1_Death");
            bossSummon01 = content.Load<SoundEffect>("SFX/Boss 1/Boss1_Summon");
            bossVictorious01 = content.Load<SoundEffect>("SFX/Boss 1/Boss1_Summon");
        }
    }
}
