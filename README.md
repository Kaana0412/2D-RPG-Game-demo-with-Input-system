# 2D-RPG-Game-demo-with-Input-system
## Development Goals | 开发目标

- Practice Unity 2D game development workflow  
- Learn and apply C# scripting in a real project  
- Build a complete combat-based gameplay loop  
- Improve understanding of FSM, Input System, animation, and UI implementation  

- 练习 Unity 2D 游戏开发的完整流程  
- 在实际项目中学习并应用 C# 脚本开发  
- 搭建一个完整的战斗玩法闭环  
- 提升对有限状态机、Input System、动画系统和 UI 实现的理解  

---

## Core Features | 核心功能

### Player System | 玩家系统
- Basic player movement  
- Jump  
- Wall jump  
- Dash  
- Character flip based on movement direction  
- Attack  
- Hurt  
- Death  

- 基础移动  
- 跳跃  
- 滑墙跳  
- 冲刺  
- 根据移动方向进行人物翻转  
- 攻击  
- 受伤  
- 死亡  

### Enemy System | 敌人系统
- Enemy patrol  
- Turn around when hitting obstacles  
- FSM-based enemy logic  
- Enemy combat behavior  
- Multiple enemy attack patterns  
- Enemy hurt and death  

- 敌人巡逻  
- 撞墙转身  
- 基于有限状态机的敌人逻辑  
- 敌人战斗行为  
- 多种敌人攻击模式  
- 敌人受伤与死亡  

### Combat System | 战斗系统
- Player and enemy damage interaction  
- Real-time health changes  
- Basic combat loop completed  

- 玩家与敌人之间的伤害交互  
- 血量实时变化  
- 基础战斗闭环完成  

### UI & Game Flow | UI 与游戏流程
- Real-time player health UI  
- Game over screen  
- Basic game flow completed  

- 玩家实时血量 UI  
- 游戏结束界面  
- 基础游戏流程完成  

---

## Technical Implementation | 技术实现

- **Engine:** Unity  
- **Language:** C#  
- **Input:** Unity Input System  
- **Architecture:** FSM (Finite State Machine) for enemy behavior  
- **Animation:** Animator + trigger/bool based transitions  
- **Collision / Damage:** Trigger-based hit detection  
- **UI:** Real-time HP display and game flow interfaces  
- **Other:** Coroutine used for timing-related logic  

- **引擎：** Unity  
- **语言：** C#  
- **输入系统：** Unity Input System  
- **架构：** 使用有限状态机（FSM）管理敌人行为  
- **动画：** 基于 Animator 的 Trigger / Bool 状态切换  
- **碰撞与伤害：** 基于 Trigger 的命中检测  
- **UI：** 实时血量显示与基础界面流程  
- **其他：** 使用协程处理部分时间控制逻辑  

---

## Highlights | 项目亮点

- Built a complete 2D combat demo instead of isolated feature practice  
- Reworked and refactored scripts during development for better understanding  
- Implemented some gameplay features through independent thinking and AI-assisted guidance rather than only following tutorials  
- Completed one full cycle of designing, implementing, debugging, and polishing a small game project  

- 完成的是一个相对完整的 2D 战斗 Demo，而不是零散功能练习  
- 在开发过程中对部分脚本进行了重新实现与重构，加深理解  
- 部分玩法功能并非完全依赖教程，而是通过独立思考与 AI 引导完成  
- 完整经历了一次小型游戏项目从设计、实现、调试到打磨收尾的过程  

---

## Controls | 操作方式

- Move: A / D or Left / Right  
- Jump: Space  
- Attack: J / Left Mouse / assigned key  
- Dash: Shift / assigned key  

- 移动：A / D 或 左右方向键  
- 跳跃：Space  
- 攻击：J 
- 冲刺：Shift / 自定义按键  

个人 Unity 学习练习项目。  
