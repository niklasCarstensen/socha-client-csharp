﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareChallengeClient
{
    /// <summary>
    /// Contains all the information of the current GameState
    /// </summary>
    public class State : ICloneable
    {
        public PlayerColor StartPlayerColor;
        public PlayerColor CurrentPlayerColor;
        public int Turn;
        public string RedDisplayName;
        public string BlueDisplayName;

        public Board CurrentBoard;

        public State()
        {
            CurrentBoard = new Board();
        }

        /// <summary>
        /// Returns a new State which represents the board after doing the given Move
        /// <para>Caution: This method will check if the Move is legal before performing it which results 
        /// in worse perofrmance. If you are using this method a lot I recommend using PerformWithoutChecks</para>
        /// </summary>
        public State Perform(Move M)
        {
            if (M.IsLegalOn(CurrentBoard, CurrentPlayerColor))
                return PerformWithoutChecks(M);
            else
                throw new IllegalMoveException();
        }
        /// <summary>
        /// Returns a new State which represents the board after doing the given Move
        /// <para>Caution: This method won't check if the move is legal before commiting it to the board. 
        /// Feeding illegal moves into this method may result in unexpected behavior</para>
        /// </summary>
        public State PerformWithoutChecks(Move M)
        {
            State re = (State)this.Clone();
            Point e = M.GetEndpointOn(re.CurrentBoard);

            re.CurrentBoard.Fields[M.X, M.Y].State = FieldState.EMPTY;
            re.CurrentBoard.Fields[e.X, e.Y].State = re.CurrentPlayerColor.ToFieldState();

            re.Turn++;
            re.CurrentPlayerColor = re.CurrentPlayerColor.OtherTeam();

            return re;
        }

        /// <summary>
        /// Creates a deep copy of this object
        /// </summary>
        public object Clone()
        {
            State s = (State)MemberwiseClone();
            s.CurrentBoard = (Board)CurrentBoard.Clone();
            return s;
        }
    }

    public enum PlayerColor { RED, BLUE }

    public class IllegalMoveException : Exception { }
}
