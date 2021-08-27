using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuplemetry;

namespace TuplemetryTester
{
    [TestClass]
    public class LineSegmentTest
    {
        #region Performance Tests

        [TestMethod]
        public void LineSegment_Intersects_Performance_Test()
        {
            for (int i = 0; 1000000 > i; i++)
            {
                LineSegment_Intersects_Tests();
            }
        }

        [TestMethod]
        public void LineSegment_Intersection_Performance_Test()
        {
            for (int i = 0; 1000000 > i; i++)
            {
                LineSegment_Intersection_Tests();
            }
        }

        #endregion

        [TestMethod]
        public void LineSegment_Crosses_Tests()
        {
            Assert.IsFalse(NQ.Crosses(CJ), "Line segment C-J was incorrectly found to cross line segment N-Q");

            Assert.IsTrue(AE.Crosses(HT), "Line segment H-T was incorrectly found to not cross line segment A-E");
            Assert.IsTrue(BE.Crosses(HT), "Line segment H-T was incorrectly found to not cross line segment B-E");
            Assert.IsFalse(HT.Crosses(BE), "Line segment B-E was incorrectly found to cross line segment H-T");

            Assert.IsFalse(AB.Crosses(BC), "Line segment B-C was incorrectly found to cross line segment A-B");
            Assert.IsFalse(AB.Crosses(BE), "Line segment B-E was incorrectly found to cross line segment A-B");
            Assert.IsFalse(AD.Crosses(DE), "Line segment D-E was incorrectly found to cross line segment A-D");

            Assert.IsFalse(BG.Crosses(FG), "Line segment F-G was incorrectly found to cross line segment B-G");
            Assert.IsFalse(FG.Crosses(BG), "Line segment B-G was incorrectly found to cross line segment F-G");

            Assert.IsFalse(IJ.Crosses(IK), "Line segment I-K was incorrectly found to cross line segment I-J");
            Assert.IsFalse(IK.Crosses(IJ), "Line segment I-J was incorrectly found to cross line segment I-K");

            Assert.IsTrue(LM.Crosses(NO), "Line segment N-O was incorrectly found to not cross line segment L-M");
            Assert.IsFalse(NO.Crosses(LM), "Line segment L-M was incorrectly found to cross line segment N-O");
            Assert.IsFalse(LO.Crosses(NO), "Line segment N-O was incorrectly found to cross line segment L-O");
            Assert.IsFalse(NO.Crosses(OQ), "Line segment O-Q was incorrectly found to cross line segment O-Q");

            Assert.IsFalse(PQ.Crosses(RS), "Line segment R-S was incorrectly found to cross line segment P-Q");
            Assert.IsFalse(RS.Crosses(PQ), "Line segment P-Q was incorrectly found to cross line segment R-S");

            Assert.IsFalse(AB.Crosses(BH), "Line segment B-H was incorrectly found to cross line segment A-B");
            Assert.IsFalse(AC.Crosses(BH), "Line segment B-H was incorrectly found to cross line segment A-C");
            Assert.IsTrue(BH.Crosses(AC), "Line segment A-C was incorrectly found to cross line segment B-H");

            Assert.IsFalse(BH.Crosses(FG), "Line segment F-G was incorrectly found to cross line segment B-H");
            Assert.IsFalse(FG.Crosses(BH), "Line segment B-H was incorrectly found to cross line segment F-G");

            Assert.IsFalse(CD.Crosses(CJ), "Line segment C-J was incorrectly found to cross line segment C-D");
            Assert.IsFalse(CJ.Crosses(CE), "Line segment C-E was incorrectly found to cross line segment C-J");

            Assert.IsFalse(BC.Crosses(CJ), "Line segment C-J was incorrectly found to cross line segment B-C");
            Assert.IsFalse(CJ.Crosses(BC), "Line segment B-C was incorrectly found to cross line segment C-J");

            Assert.IsFalse(LM.Crosses(LP), "Line segment L-P was incorrectly found to cross line segment L-M");
            Assert.IsFalse(LM.Crosses(LN), "Line segment L-N was incorrectly found to cross line segment L-M");

            Assert.IsTrue(CJ.Crosses(IK), "Line segment I-K was incorrectly found to cross line segment C-J");
            Assert.IsFalse(IK.Crosses(CJ), "Line segment C-J was incorrectly found to cross line segment I-K");

            Assert.IsTrue(CJ.Crosses(BE), "Line segment B-E was incorrectly found to cross line segment C-J");
            Assert.IsFalse(BE.Crosses(CJ), "Line segment C-J was incorrectly found to cross line segment B-E");

            Assert.IsTrue(BF.Crosses(AC), "Line segment A-C was incorrectly found to cross line segment B-F");
            Assert.IsFalse(AC.Crosses(BF), "Line segment B-F was incorrectly found to cross line segment A-C");

            Assert.IsTrue(IL.Crosses(TV), "Line segment T-V was incorrectly found to cross line segment I-L");
            Assert.IsTrue(LM.Crosses(NQ), "Line segment N-Q was incorrectly found to cross line segment L-M");
            Assert.IsFalse(NO.Crosses(LM), "Line segment L-M was incorrectly found to cross line segment N-O");
        }

        [TestMethod]
        public void LineSegment_Touches_Tests()
        {
            Assert.IsFalse(AB.Touches(CD), "Line segment C-D was incorrectly found to touch line segment A-B");

            Assert.IsTrue(AB.Touches(BC), "Line segment B-C was incorrectly found to not touch line segment A-B");
            Assert.IsTrue(AB.Touches(BE), "Line segment B-E was incorrectly found to not touch line segment A-B");
            Assert.IsTrue(AD.Touches(DE), "Line segment D-E was incorrectly found to not touch line segment A-D");

            Assert.IsTrue(BG.Touches(FG), "Line segment F-G was incorrectly found to not touch line segment B-G");
            Assert.IsTrue(FG.Touches(BG), "Line segment B-G was incorrectly found to not touch line segment F-G");

            Assert.IsTrue(IJ.Touches(IK), "Line segment I-K was incorrectly found to not touch line segment I-J");
            Assert.IsTrue(IK.Touches(IJ), "Line segment I-J was incorrectly found to not touch line segment I-K");

            Assert.IsFalse(LM.Touches(NO), "Line segment N-O was incorrectly found to touch line segment L-M");
            Assert.IsTrue(NO.Touches(LM), "Line segment L-M was incorrectly found to not touch line segment N-O");
            Assert.IsTrue(LO.Touches(NO), "Line segment N-O was incorrectly found to not touch line segment L-O");
            Assert.IsTrue(NO.Touches(OQ), "Line segment O-Q was incorrectly found to not touch line segment O-Q");

            Assert.IsFalse(PQ.Touches(RS), "Line segment R-S was incorrectly found to touch line segment P-Q");
            Assert.IsFalse(RS.Touches(PQ), "Line segment P-Q was incorrectly found to touch line segment R-S");

            Assert.IsTrue(AB.Touches(BH), "Line segment B-H was incorrectly found to not touch line segment A-B");
            Assert.IsTrue(AC.Touches(BH), "Line segment B-H was incorrectly found to not touch line segment A-C");
            Assert.IsFalse(BH.Touches(AC), "Line segment A-C was incorrectly found to touch line segment B-H");

            Assert.IsFalse(BH.Touches(FG), "Line segment F-G was incorrectly found to touch line segment B-H");
            Assert.IsFalse(FG.Touches(BH), "Line segment B-H was incorrectly found to touch line segment F-G");

            Assert.IsTrue(CD.Touches(CJ), "Line segment C-J was incorrectly found to not touch line segment C-D");
            Assert.IsTrue(CJ.Touches(CE), "Line segment C-E was incorrectly found to not touch line segment C-J");

            Assert.IsTrue(BC.Touches(CJ), "Line segment C-J was incorrectly found to not touch line segment B-C");
            Assert.IsTrue(CJ.Touches(BC), "Line segment B-C was incorrectly found to not touch line segment C-J");

            Assert.IsTrue(LM.Touches(LP), "Line segment L-P was incorrectly found to not touch line segment L-M");
            Assert.IsTrue(LM.Touches(LN), "Line segment L-N was incorrectly found to not touch line segment L-M");

            Assert.IsFalse(CJ.Touches(IK), "Line segment I-K was incorrectly found to touch line segment C-J");
            Assert.IsTrue(IK.Touches(CJ), "Line segment C-J was incorrectly found to not touch line segment I-K");

            Assert.IsFalse(CJ.Touches(BE), "Line segment B-E was incorrectly found to touch line segment C-J");
            Assert.IsTrue(BE.Touches(CJ), "Line segment C-J was incorrectly found to not touch line segment B-E");

            Assert.IsFalse(BF.Touches(AC), "Line segment A-C was incorrectly found to touch line segment B-F");
            Assert.IsTrue(AC.Touches(BF), "Line segment B-F was incorrectly found to not touch line segment A-C");

            Assert.IsFalse(LM.Touches(NQ), "Line segment N-Q was incorrectly found to touch line segment L-M");
            Assert.IsTrue(NO.Touches(LM), "Line segment L-M was incorrectly found to not touch line segment N-O");
        }

        [TestMethod]
        public void LineSegment_Branches_Tests()
        {
            Assert.IsFalse(AB.Branches(CD), "Line segment C-D was incorrectly found to branch line segment A-B");

            Assert.IsFalse(AB.Branches(BC), "Line segment B-C was incorrectly found to branch line segment A-B");
            Assert.IsFalse(AB.Branches(BE), "Line segment B-E was incorrectly found to branch line segment A-B");
            Assert.IsFalse(AD.Branches(DE), "Line segment D-E was incorrectly found to branch line segment A-D");

            Assert.IsFalse(BG.Branches(FG), "Line segment F-G was incorrectly found to branch line segment B-G");
            Assert.IsFalse(FG.Branches(BG), "Line segment B-G was incorrectly found to branch line segment F-G");

            Assert.IsFalse(IJ.Branches(IK), "Line segment I-K was incorrectly found to branch line segment I-J");
            Assert.IsFalse(IK.Branches(IJ), "Line segment I-J was incorrectly found to branch line segment I-K");

            Assert.IsFalse(LM.Branches(NO), "Line segment N-O was incorrectly found to branch line segment N-O");
            Assert.IsFalse(LO.Branches(NO), "Line segment N-O was incorrectly found to branch line segment N-O");
            Assert.IsFalse(NO.Branches(OQ), "Line segment O-Q was incorrectly found to branch line segment O-Q");

            Assert.IsFalse(PQ.Branches(RS), "Line segment R-S was incorrectly found to branch line segment P-Q");
            Assert.IsFalse(RS.Branches(PQ), "Line segment P-Q was incorrectly found to branch line segment R-S");

            Assert.IsFalse(AB.Branches(BH), "Line segment B-H was incorrectly found to branch line segment A-B");
            Assert.IsTrue(AC.Branches(BH), "Line segment B-H was incorrectly found to not branch line segment A-C");
            Assert.IsFalse(BH.Branches(AC), "Line segment A-C was incorrectly found to branch line segment B-H");

            Assert.IsFalse(BH.Branches(FG), "Line segment F-G was incorrectly found to branch line segment B-H");
            Assert.IsFalse(FG.Branches(BH), "Line segment B-H was incorrectly found to branch line segment F-G");

            Assert.IsFalse(CD.Branches(CJ), "Line segment C-J was incorrectly found to branch line segment C-D");
            Assert.IsFalse(CJ.Branches(CE), "Line segment C-E was incorrectly found to branch line segment C-J");

            Assert.IsFalse(BC.Branches(CJ), "Line segment C-J was incorrectly found to branch line segment B-C");
            Assert.IsFalse(CJ.Branches(BC), "Line segment B-C was incorrectly found to branch line segment C-J");

            Assert.IsFalse(LM.Branches(LP), "Line segment L-P was incorrectly found to branch line segment L-M");
            Assert.IsFalse(LM.Branches(LN), "Line segment L-N was incorrectly found to branch line segment L-M");

            Assert.IsFalse(CJ.Branches(IK), "Line segment I-K was incorrectly found to branch line segment C-J");
            Assert.IsTrue(IK.Branches(CJ), "Line segment C-J was incorrectly found to not branch line segment I-K");

            Assert.IsFalse(CJ.Branches(BE), "Line segment B-E was incorrectly found to branch line segment C-J");
            Assert.IsTrue(BE.Branches(CJ), "Line segment C-J was incorrectly found to not branch line segment B-E");

            Assert.IsFalse(BF.Branches(AC), "Line segment A-B was incorrectly found to branch line segment B-F");
            Assert.IsTrue(AC.Branches(BF), "Line segment B-F was incorrectly found to not branch line segment A-C");

            Assert.IsFalse(LM.Branches(NQ), "Line segment N-Q was incorrectly found to branch line segment L-M");
            Assert.IsTrue(NO.Branches(LM), "Line segment L-M was incorrectly found to not branch line segment N-O");
        }

        [TestMethod]
        public void LineSegment_Bends_Tests()
        {
            Assert.IsFalse(AB.Bends(CD), "Line segment C-D was incorrectly found to bend line segment A-B");

            Assert.IsFalse(AB.Bends(BC), "Line segment B-C was incorrectly found to bend line segment A-B");
            Assert.IsFalse(AB.Bends(BE), "Line segment B-E was incorrectly found to bend line segment A-B");
            Assert.IsFalse(AD.Bends(DE), "Line segment D-E was incorrectly found to bend line segment A-D");

            Assert.IsFalse(BG.Bends(FG), "Line segment F-G was incorrectly found to bend line segment B-G");
            Assert.IsFalse(FG.Bends(BG), "Line segment B-G was incorrectly found to bend line segment F-G");

            Assert.IsFalse(IJ.Bends(IK), "Line segment I-K was incorrectly found to bend line segment I-J");
            Assert.IsFalse(IK.Bends(IJ), "Line segment I-J was incorrectly found to bend line segment I-K");

            Assert.IsFalse(LM.Bends(NO), "Line segment N-O was incorrectly found to bend line segment N-O");
            Assert.IsFalse(LO.Bends(NO), "Line segment N-O was incorrectly found to bend line segment N-O");
            Assert.IsFalse(NO.Bends(OQ), "Line segment O-Q was incorrectly found to bend line segment O-Q");

            Assert.IsFalse(PQ.Bends(RS), "Line segment R-S was incorrectly found to bend line segment P-Q");
            Assert.IsFalse(RS.Bends(PQ), "Line segment P-Q was incorrectly found to bend line segment R-S");

            Assert.IsTrue(AB.Bends(BH), "Line segment B-H was incorrectly found to not bend line segment A-B");
            Assert.IsFalse(AC.Bends(BH), "Line segment B-H was incorrectly found to bend line segment A-C");

            Assert.IsFalse(BH.Bends(FG), "Line segment F-G was incorrectly found to bend line segment B-H");
            Assert.IsFalse(FG.Bends(BH), "Line segment B-H was incorrectly found to bend line segment F-G");

            Assert.IsTrue(CD.Bends(CJ), "Line segment C-J was incorrectly found to not bend line segment C-D");
            Assert.IsTrue(CJ.Bends(CE), "Line segment C-E was incorrectly found to not bend line segment C-J");

            Assert.IsTrue(BC.Bends(CJ), "Line segment C-J was incorrectly found to not bend line segment B-C");
            Assert.IsTrue(CJ.Bends(BC), "Line segment B-C was incorrectly found to not bend line segment C-J");

            Assert.IsTrue(LM.Bends(LP), "Line segment L-P was incorrectly found to not bend line segment L-M");
            Assert.IsTrue(LM.Bends(LN), "Line segment L-N was incorrectly found to not bend line segment L-M");
        }

        [TestMethod]
        public void LineSegment_Congruent_Tests()
        {
            Assert.IsTrue(AB.Congruent(AB), "Line segment A-B was incorrectly found to be not congruent to line segment A-B");

            Assert.IsFalse(AB.Congruent(BC), "Line segment B-C was incorrectly found to be congruent to line segment A-B");
            Assert.IsFalse(AB.Congruent(BE), "Line segment B-E was incorrectly found to be congruent to line segment A-B");
            Assert.IsTrue(CD.Congruent(DE), "Line segment D-E was incorrectly found to be not congruent to line segment A-D");

            Assert.IsFalse(BG.Congruent(FG), "Line segment F-G was incorrectly found to be congruent to line segment B-G");
            Assert.IsFalse(FG.Congruent(BG), "Line segment B-G was incorrectly found to be congruent to line segment F-G");

            Assert.IsFalse(IJ.Congruent(IK), "Line segment I-K was incorrectly found to be congruent to line segment I-J");
            Assert.IsFalse(IK.Congruent(IJ), "Line segment I-J was incorrectly found to be congruent to line segment I-K");

            Assert.IsTrue(NO.Congruent(NO), "Line segment N-O was incorrectly found to be congruent to line segment N-O");
            Assert.IsFalse(LO.Congruent(NO), "Line segment N-O was incorrectly found to be congruent to line segment N-O");
            Assert.IsFalse(NO.Congruent(OQ), "Line segment O-Q was incorrectly found to be congruent to line segment O-Q");

            Assert.IsFalse(PQ.Congruent(RS), "Line segment R-S was incorrectly found to be congruent to line segment P-Q");
            Assert.IsFalse(RS.Congruent(PQ), "Line segment P-Q was incorrectly found to be congruent to line segment R-S");

            Assert.IsTrue(UV.Congruent(BV), "Line segment B-V was incorrectly found to not be congruent to line segment U-V");
            Assert.IsFalse(AC.Congruent(BH), "Line segment B-H was incorrectly found to be congruent to line segment A-C");

            Assert.IsFalse(BH.Congruent(FG), "Line segment F-G was incorrectly found to be congruent to line segment B-H");
            Assert.IsFalse(FG.Congruent(BH), "Line segment B-H was incorrectly found to be congruent to line segment F-G");

            Assert.IsTrue(JU.Congruent(BV), "Line segment B-V was incorrectly found to not be congruent to line segment J-U");
            Assert.IsTrue(BV.Congruent(JU), "Line segment J-U was incorrectly found to not be congruent to line segment B-V");

            Assert.IsTrue(BC.Congruent(BG), "Line segment B-G was incorrectly found to not be congruent to line segment B-C");
            Assert.IsTrue(BG.Congruent(BC), "Line segment B-C was incorrectly found to not be congruent to line segment B-G");

            Assert.IsTrue(LM.Congruent(OP), "Line segment O-P was incorrectly found to not be congruent to line segment L-M");
            Assert.IsTrue(OP.Congruent(LM), "Line segment L-M was incorrectly found to not be congruent to line segment O-P");
        }

        [TestMethod]
        public void LineSegment_Outsects_Tests()
        {
            Assert.IsTrue(BH.Outsects(UV), "Line segment U-V was incorrectly found to be not outsect to line segment B-H");
            Assert.IsTrue(UV.Outsects(BH), "Line segment B-H was incorrectly found to be not outsect to line segment U-V");
            Assert.IsFalse(UV.Outsects(BV), "Line segment B-V was incorrectly found to outsect line segment U-V");

            Assert.IsFalse(AB.Outsects(BC), "Line segment B-C was incorrectly found to outsect line segment A-B");
            Assert.IsFalse(AB.Outsects(BE), "Line segment B-E was incorrectly found to outsect line segment A-B");
            Assert.IsTrue(AB.Outsects(CE), "Line segment C-E was incorrectly found to be not outsect line segment A-B");

            Assert.IsFalse(BG.Outsects(FG), "Line segment F-G was incorrectly found to outsect line segment B-G");
            Assert.IsFalse(FG.Outsects(BG), "Line segment B-G was incorrectly found to outsect line segment F-G");

            Assert.IsFalse(IJ.Outsects(IK), "Line segment I-K was incorrectly found to outsect line segment I-J");
            Assert.IsFalse(IK.Outsects(IJ), "Line segment I-J was incorrectly found to outsect line segment I-K");

            Assert.IsTrue(BC.Outsects(DE), "Line segment D-E was incorrectly found to outsect line segment B-C");
            Assert.IsTrue(DE.Outsects(BC), "Line segment B-C was incorrectly found to outsect line segment D-E");

            Assert.IsTrue(JU.Outsects(BV), "Line segment B-V was incorrectly found to outsect line segment J-U");
            Assert.IsTrue(BV.Outsects(JU), "Line segment J-U was incorrectly found to outsect line segment B-V");

            Assert.IsFalse(PQ.Outsects(RS), "Line segment R-S was incorrectly found to outsect line segment P-Q");
            Assert.IsFalse(RS.Outsects(PQ), "Line segment P-Q was incorrectly found to outsect line segment R-S");

            Assert.IsFalse(UV.Outsects(BV), "Line segment B-V was incorrectly found to outsect line segment U-V");
            Assert.IsFalse(AC.Outsects(BH), "Line segment B-H was incorrectly found to outsect line segment A-C");

            Assert.IsTrue(IJ.Outsects(KL), "Line segment K-L was incorrectly found to outsect line segment I-J");
            Assert.IsTrue(KL.Outsects(IJ), "Line segment I-J was incorrectly found to outsect line segment K-L");

            Assert.IsTrue(JU.Outsects(BV), "Line segment B-V was incorrectly found to not outsect line segment J-U");
            Assert.IsTrue(BV.Outsects(JU), "Line segment J-U was incorrectly found to not outsect line segment B-V");

            Assert.IsTrue(FG.Outsects(new LineSegment(B, B)), "Line segment B-B was incorrectly found to not outsect line segment F-G");
            Assert.IsTrue(new LineSegment(B, B).Outsects(FG), "Line segment F-G was incorrectly found to not outsect line segment B-B");

            Assert.IsTrue(new LineSegment(O, O).Outsects(new LineSegment(B, B)), "Line segment B-B was incorrectly found to not outsect line segment O-O");
            Assert.IsTrue(new LineSegment(E, E).Outsects(new LineSegment(Q, Q)), "Line segment F-G was incorrectly found to not outsect line segment B-B");
        }

        [TestMethod]
        public void LineSegment_Extends_Tests()
        {
            Assert.IsFalse(AB.Extends(CD), "Line segment C-D was incorrectly found to extend line segment A-B");

            Assert.IsTrue(AB.Extends(BC), "Line segment B-c was incorrectly found to not extend line segment A-B");
            Assert.IsTrue(AB.Extends(BE), "Line segment B-E was incorrectly found to not extend line segment A-B");
            Assert.IsTrue(AD.Extends(DE), "Line segment D-E was incorrectly found to not extend line segment A-D");

            Assert.IsTrue(BG.Extends(FG), "Line segment F-G was incorrectly found to not extend line segment B-G");
            Assert.IsTrue(FG.Extends(BG), "Line segment B-G was incorrectly found to not extend line segment F-G");

            Assert.IsFalse(IJ.Extends(IK), "Line segment I-K was incorrectly found to extend line segment I-J");
            Assert.IsFalse(IK.Extends(IJ), "Line segment I-J was incorrectly found to extend line segment I-K");

            Assert.IsFalse(LM.Extends(NO), "Line segment N-O was incorrectly found to extend line segment N-O");
            Assert.IsFalse(LO.Extends(NO), "Line segment N-O was incorrectly found to extend line segment N-O");
            Assert.IsTrue(NO.Extends(OQ), "Line segment O-Q was incorrectly found to not extend line segment O-Q");

            Assert.IsFalse(PQ.Extends(RS), "Line segment R-S was incorrectly found to extend line segment P-Q");
            Assert.IsFalse(RS.Extends(PQ), "Line segment P-Q was incorrectly found to extend line segment R-S");
        }

        [TestMethod]
        public void LineSegment_Eschews_Tests()
        {
            Assert.IsFalse(AB.Eschews(CD), "Line segment C-D was incorrectly found to eschew line segment A-B");
            Assert.IsFalse(CD.Eschews(AB), "Line segment A-B was incorrectly found to eschew line segment C-D");

            Assert.IsFalse(BH.Eschews(UV), "Line segment U-V was incorrectly found to eschew line segment B-H");
            Assert.IsFalse(AB.Eschews(BE), "Line segment B-H was incorrectly found to eschew line segment U-V");

            Assert.IsFalse(OP.Eschews(LN), "Line segment L-N was incorrectly found to eschew line segment O-P");
            Assert.IsFalse(LN.Eschews(OP), "Line segment O-P was incorrectly found to eschew line segment L-N");

            Assert.IsFalse(BG.Eschews(FG), "Line segment F-G was incorrectly found to eschew line segment B-G");
            Assert.IsFalse(FG.Eschews(BG), "Line segment B-G was incorrectly found to eschew line segment F-G");

            Assert.IsFalse(BJ.Eschews(UV), "Line segment U-V was incorrectly found to eschew line segment B-J");
            Assert.IsFalse(FG.Eschews(BG), "Line segment B-J was incorrectly found to eschew line segment U-V");

            Assert.IsFalse(IL.Eschews(IL), "Line segment I-L was incorrectly found to eschew line segment I-L");
            Assert.IsFalse(NQ.Eschews(NQ), "Line segment N-Q was incorrectly found to eschew line segment N-Q");

            Assert.IsFalse(HT.Eschews(new LineSegment(E, Q)), "Line segment E-Q was incorrectly found to eschew line segment H-T");
            Assert.IsFalse(new LineSegment(Q, E).Eschews(HT), "Line segment H-T was incorrectly found to eschew line segment Q-E");

            Assert.IsTrue(IM.Eschews(DE), "Line segment D-E was incorrectly found to not eschew line segment I-M");
            Assert.IsTrue(DE.Eschews(IM), "Line segment I-M was incorrectly found to not eschew line segment D-E");

            Assert.IsTrue(PQ.Eschews(BG), "Line segment B-G was incorrectly found to not eschew line segment P-Q");
            Assert.IsTrue(BG.Eschews(PQ), "Line segment P-Q was incorrectly found to not eschew line segment B-G");

            Assert.IsTrue(LO.Eschews(RS), "Line segment R-S was incorrectly found to not eschew line segment L-O");
            Assert.IsTrue(RS.Eschews(LO), "Line segment L-O was incorrectly found to not eschew line segment R-S");

            Assert.IsTrue(new LineSegment(F, U).Eschews(new LineSegment(V, G)), "Line segment V-G was incorrectly found to not eschew line segment F-U");
            Assert.IsTrue(new LineSegment(L, D).Eschews(new LineSegment(B, O)), "Line segment B-O was incorrectly found to not eschew line segment L-D");

            Assert.IsTrue(JT.Eschews(new LineSegment(Q, Q)), "Line segment J-T was incorrectly found to not eschew line segment Q-Q");

            // All points are effectively "parallel" and therefore fail the collinear requirement of eschewment

            Assert.IsFalse(new LineSegment(A, A).Eschews(new LineSegment(B, B)), "Line segment B-B was incorrectly found to not eschew line segment A-A");
        }

        [TestMethod]
        public void LineSegment_Overlaps_Tests()
        {
            Assert.IsFalse(AB.Overlaps(CD), "Line segment A-B was incorrectly found to overlap line segment C-D");

            Assert.IsTrue(AE.Overlaps(AE), "Line segment A-E was incorrectly found to not overlap line segment A-E");
            Assert.IsTrue(AE.Overlaps(CD), "Line segment A-E was incorrectly found to not overlap line segment C-D");
            Assert.IsTrue(CE.Overlaps(CD), "Line segment C-E was incorrectly found to not overlap line segment C-D");
            Assert.IsTrue(NQ.Overlaps(OP), "Line segment N-Q was incorrectly found to not overlap line segment O-P");

            Assert.IsTrue(IJ.Overlaps(IK), "Line segment I-J was incorrectly found to not overlap line segment I-K");
            Assert.IsTrue(IK.Overlaps(IJ), "Line segment I-K was incorrectly found to not overlap line segment I-J");

            Assert.IsFalse(LM.Overlaps(NO), "Line segment L-M was incorrectly found to overlap line segment N-O");
            Assert.IsTrue(LO.Overlaps(NO), "Line segment L-O was incorrectly found to not overlap line segment N-O");

            Assert.IsFalse(PQ.Overlaps(RS), "Line segment P-Q was incorrectly found to overlap line segment R-S");
            Assert.IsFalse(RS.Overlaps(PQ), "Line segment R-S was incorrectly found to overlap line segment P-Q");
        }

        [TestMethod]
        public void LineSegment_Contains_Tests()
        {
            Assert.IsFalse(AB.Contains(CD), "Line segment A-B was incorrectly found to contain line segment C-D");

            Assert.IsTrue(AE.Contains(AE), "Line segment A-E was incorrectly found to not contain line segment A-E");
            Assert.IsTrue(AE.Contains(CD), "Line segment A-E was incorrectly found to not contain line segment C-D");
            Assert.IsTrue(CE.Contains(CD), "Line segment C-E was incorrectly found to not contain line segment C-D");
            Assert.IsTrue(NQ.Contains(OP), "Line segment N-Q was incorrectly found to not contain line segment O-P");

            Assert.IsFalse(IJ.Contains(IK), "Line segment I-J was incorrectly found to contain line segment I-K");
            Assert.IsTrue(IK.Contains(IJ), "Line segment I-K was incorrectly found to not contain line segment I-J");

            Assert.IsFalse(LM.Contains(NO), "Line segment L-M was incorrectly found to contain line segment N-O");
            Assert.IsFalse(LO.Contains(NO), "Line segment L-O was incorrectly found to contain line segment N-O");

            Assert.IsFalse(PQ.Contains(RS), "Line segment P-Q was incorrectly found to contain line segment R-S");
            Assert.IsFalse(RS.Contains(PQ), "Line segment R-S was incorrectly found to contain line segment P-Q");
        }

        [TestMethod]
        public void LineSegment_Collinear_Tests()
        {
            Assert.IsFalse(CJ.Collinear(OP), "Line segment C-J was incorrectly found to be collinear with line segment O-P");
            Assert.IsFalse(BH.Collinear(RS), "Line segment B-H was incorrectly found to be collinear with line segment R-S");
            Assert.IsFalse(CJ.Collinear(RS), "Line segment C-J was incorrectly found to be collinear with line segment R-S");

            Assert.IsTrue(LineSegment.Collinear(AB.A, AB.B, AB.A, AB.B), "Line segment A-B was incorrectly found to not be collinear with line segment A-B");
            Assert.IsTrue(AB.Collinear(CD), "Line segment A-B was incorrectly found to not be collinear with line segment C-D");
            Assert.IsTrue(AD.Collinear(CE), "Line segment A-D was incorrectly found to not be collinear with line segment C-E");
            Assert.IsTrue(NL.Collinear(PQ), "Line segment N-L was incorrectly found to not be collinear with line segment P-Q");
            Assert.IsTrue(LN.Collinear(PQ), "Line segment L-N was incorrectly found to not be collinear with line segment P-Q");
        }

        [TestMethod]
        public void LineSegment_Paralell_Tests()
        {
            Assert.IsTrue(AB.Parallel(CD), "Line segment A-B was incorrectly found to not be parallel to line segment C-D");

            Assert.IsFalse(AB.Parallel(BH), "Line segment A-B was incorrectly found to be parallel to line segment B-H");

            Assert.IsTrue(BH.Parallel(RS), "Line segment B-H was incorrectly found to not be parallel to line segment R-S");

            Assert.IsFalse(CJ.Parallel(RS), "Line segment C-J was incorrectly found to not be parallel to line segment R-S");

            Assert.IsTrue(LineSegment.Parallel(AB.A, AB.B, AB.A, AB.B), "Line segment A-B was incorrectly found to be not parallel to line segment A-B");
        }

        [TestMethod]
        public void LineSegment_Perpendicular_Tests()
        {
            Assert.IsFalse(AB.Perpendicular(CD), "Line segment C-D was incorrectly found to be perpendicular to line segment A-B");

            Assert.IsFalse(AB.Perpendicular(BH), "Line segment B-H was incorrectly found to be perpendicular to line segment A-B");

            Assert.IsTrue(BC.Perpendicular(BG), "Line segment B-G was incorrectly found to not be perpendicular to line segment B-C");

            Assert.IsTrue(BC.Perpendicular(FG), "Line segment F-G was incorrectly found to not be perpendicular to line segment B-C");

            Assert.IsTrue(CJ.Perpendicular(JK), "Line segment J-K was incorrectly found to not be perpendicular to line segment C-J");

            Assert.IsTrue(CJ.Perpendicular(LM), "Line segment L-M was incorrectly found to not be perpendicular to line segment C-J");

            Assert.IsTrue(LM.Perpendicular(CJ), "Line segment C-J was incorrectly found to not be perpendicular to line segment L-M");

            Assert.IsTrue(IJ.Perpendicular(OP), "Line segment O-P was incorrectly found to not be perpendicular to line segment I-J");

            Assert.IsFalse(IJ.Perpendicular(DE), "Line segment D-E was incorrectly found to not be perpendicular to line segment I-J");
            Assert.IsFalse(DE.Perpendicular(IJ), "Line segment I-J was incorrectly found to not be perpendicular to line segment D-E");

            Assert.IsFalse(LineSegment.Perpendicular(AB.A, AB.B, AB.A, AB.B), "Line segment A-B was incorrectly found to be perpendicular to line segment A-B");
        }

        [TestMethod]
        public void LineSegment_Equals_Tests()
        {
            Assert.IsFalse(AB.Equals(BH), "Line segment B-H was incorrectly found to be equal to line segment A-B");

            Assert.IsFalse(BC.Equals(BG), "Line segment B-G was incorrectly found to be equal to line segment B-C");

            Assert.IsFalse(BC.Equals(FG), "Line segment F-G was incorrectly found to be equal to line segment B-C");

            Assert.IsFalse(CJ.Equals(JK), "Line segment J-K was incorrectly found to be equal to line segment C-J");

            Assert.IsFalse(CJ.Equals(LM), "Line segment L-M was incorrectly found to be equal to line segment C-J");

            Assert.IsFalse(LM.Equals(CJ), "Line segment C-J was incorrectly found to be equal to line segment L-M");

            Assert.IsFalse(IJ.Equals(OP), "Line segment O-P was incorrectly found to be equal to line segment I-J");

            Assert.IsFalse(IJ.Equals(DE), "Line segment D-E was incorrectly found to be equal to line segment I-J");
            Assert.IsFalse(DE.Equals(IJ), "Line segment I-J was incorrectly found to be equal to line segment D-E");

            Assert.IsTrue(CD.Equals(CD), "Line segment C-D was incorrectly found to be equal to line segment C-D");

            Assert.IsTrue(AB.Equals(AB), "Line segment A-B was incorrectly found to be not equal to line segment A-B");
            Assert.IsTrue(AB.Equals(new LineSegment(AB.B, AB.A)), "Line segment A-B was incorrectly found to be not equal to line segment B-A");
            Assert.IsTrue(new LineSegment(AB.B, AB.A).Equals(AB), "Line segment B-A was incorrectly found to be not equal to line segment A-B");
            Assert.IsTrue(new LineSegment(AB.B, AB.A).Equals(new LineSegment(AB.B, AB.A)), "Line segment B-A was incorrectly found to be not equal to line segment B-A");
            
            Assert.IsTrue(LineSegment.Equals(AB.A, AB.B, AB.A, AB.B), "Line segment A-B was incorrectly found to be not equal to line segment A-B");
            Assert.IsTrue(LineSegment.Equals(AB.B, AB.A, AB.A, AB.B), "Line segment B-A was incorrectly found to be not equal to line segment A-B");
            Assert.IsTrue(LineSegment.Equals(AB.B, AB.A, AB.B, AB.A), "Line segment B-A was incorrectly found to be not equal to line segment B-A");
        }

        [TestMethod]
        public void LineSegment_Intersects_Tests()
        {
            // Point intersection

            Assert.IsFalse(CD.Intersects(B), "Line segment (point) B-B was incorrectly found to intersect line segment C-D");
            Assert.IsFalse(FG.Intersects(B), "Line segment (point) B-B was incorrectly found to intersect line segment F-G");
            Assert.IsFalse(JV.Intersects(B), "Line segment (point) B-B was incorrectly found to intersect line segment J-V");
            Assert.IsFalse(JV.Intersects(O), "Line segment (point) O-O was incorrectly found to intersect line segment J-V");
            Assert.IsFalse(RS.Intersects(Q), "Line segment (point) Q-Q was incorrectly found to intersect line segment R-S");

            Assert.IsTrue(AE.Intersects(C), "Line segment (point) C-C was incorrectly found to not intersect line segment A-E");
            Assert.IsTrue(JV.Intersects(U), "Line segment (point) U-U was incorrectly found to not intersect line segment J-V");

            // Line segment intersection
            
            Assert.IsFalse(AB.Intersects(CD), "Line segment A-B was incorrectly found to not intersect line segment C-D");
            Assert.IsFalse(OP.Intersects(CE), "Line segment C-E was incorrectly found to intersect line segment O-P");
            Assert.IsFalse(CE.Intersects(OP), "Line segment O-P was incorrectly found to intersect line segment C-E");
            Assert.IsFalse(RS.Intersects(UV), "Line segment U-V was incorrectly found to intersect line segment R-S");
            Assert.IsFalse(UV.Intersects(RS), "Line segment U-V was incorrectly found to intersect line segment U-V");

            Assert.IsTrue(AB.Intersects(AB), "Line segment A-B was incorrectly found to not intersect line segment A-B");
            Assert.IsTrue(AB.Intersects(BH), "Line segment A-B was incorrectly found to not intersect line segment B-H");

            Assert.IsTrue(CD.Intersects(BE), "Line segment B-E was incorrectly found to not intersect line segment C-D");
            Assert.IsTrue(BE.Intersects(CD), "Line segment C-D was incorrectly found to not intersect line segment B-E");

            Assert.IsTrue(BG.Intersects(BF), "Line segment B-F was incorrectly found to not intersect line segment B-G");
            Assert.IsTrue(BF.Intersects(BG), "Line segment B-G was incorrectly found to not intersect line segment B-F");

            Assert.IsTrue(BJ.Intersects(UV), "Line segment U-V was incorrectly found to not intersect line segment B-J");
            Assert.IsTrue(UV.Intersects(BJ), "Line segment B-J was incorrectly found to not intersect line segment U-V");

            Assert.IsTrue(LN.Intersects(LM), "Line segment L-M was incorrectly found to not intersect line segment L-N");
            Assert.IsTrue(LM.Intersects(LN), "Line segment L-N was incorrectly found to not intersect line segment L-M");

            Assert.IsTrue(LN.Intersects(LO), "Line segment L-O was incorrectly found to not intersect line segment L-N");
            Assert.IsTrue(LO.Intersects(LN), "Line segment L-N was incorrectly found to not intersect line segment L-O");

            Assert.IsTrue(LN.Intersects(KL), "Line segment K-L was incorrectly found to not intersect line segment L-N");
            Assert.IsTrue(KL.Intersects(LN), "Line segment L-N was incorrectly found to not intersect line segment K-L");

            Assert.IsTrue(NO.Intersects(LM), "Line segment L-M was incorrectly found to not intersect line segment N-O");
            Assert.IsTrue(LM.Intersects(NO), "Line segment N-O was incorrectly found to not intersect line segment L-M");

            Assert.IsTrue(NO.Intersects(LO), "Line segment L-O was incorrectly found to not intersect line segment N-O");
            Assert.IsTrue(LO.Intersects(NO), "Line segment N-O was incorrectly found to not intersect line segment L-O");

            Assert.IsTrue(NO.Intersects(KL), "Line segment K-L was incorrectly found to not intersect line segment N-O");
            Assert.IsTrue(KL.Intersects(NO), "Line segment N-O was incorrectly found to not intersect line segment K-L");

            Assert.IsTrue(NQ.Intersects(IM), "Line segment I-M was incorrectly found to not intersect line segment N-Q");

            Assert.IsTrue(JL.Intersects(IM), "Line segment I-M was incorrectly found to not intersect line segment J-L");
            Assert.IsTrue(IM.Intersects(JL), "Line segment J-L was incorrectly found to not intersect line segment I-M");

            Assert.IsTrue(HT.Intersects(IM), "Line segment I-M was incorrectly found to not intersect line segment H-T");
            Assert.IsTrue(IM.Intersects(HT), "Line segment H-T was incorrectly found to not intersect line segment I-M");

            Assert.IsTrue(BT.Intersects(HV), "Line segment H-V was incorrectly found to not intersect line segment B-T");
            Assert.IsTrue(HV.Intersects(BT), "Line segment B-T was incorrectly found to not intersect line segment H-V");

            Assert.IsTrue(HT.Intersects(UV), "Line segment U-V was incorrectly found to not intersect line segment H-T");
            Assert.IsTrue(UV.Intersects(HT), "Line segment H-T was incorrectly found to not intersect line segment U-V");

            Assert.IsTrue(HT.Intersects(BH), "Line segment B-H was incorrectly found to not intersect line segment H-T");
            Assert.IsTrue(BH.Intersects(HT), "Line segment H-T was incorrectly found to not intersect line segment B-H");
        }

        [TestMethod]
        public void LineSegment_Intersection_Tests()
        {
            LineSegment Result;

            Result = AB.Intersection(AB);
            Assert.IsNotNull(Result, "Line segment A-B was incorrectly found to not intersect A-B");
            Assert.IsTrue(AB == Result, "Line segment A-B was incorrectly found to intersect A-B at: " + Result);

            Result = AB.Intersection(CD);
            Assert.IsNull(Result, "Line segment A-B was incorrectly found to intersect C-D at: " + Result);

            Result = AB.Intersection(BH);
            Assert.IsNotNull(Result, "Line segment B-H was incorrectly found to not intersect A-B");
            Assert.IsTrue(BB == Result, "Line segment A-B was incorrectly found to intersect B-H at: " + Result);

            Result = AC.Intersection(AB);
            Assert.IsNotNull(Result, "Line segment A-B was incorrectly found to not intersect A-C");
            Assert.IsTrue(AB == Result, "Line segment A-B was incorrectly found to intersect A-C at: " + Result);

            Result = AC.Intersection(EC);
            Assert.IsNotNull(Result, "Line segment E-C was incorrectly found to not intersect A-C");
            Assert.IsTrue(CC == Result, "Line segment E-C was incorrectly found to intersect A-C at: " + Result);

            Result = AC.Intersection(CE);
            Assert.IsNotNull(Result, "Line segment C-E was incorrectly found to not intersect A-C");
            Assert.IsTrue(CC == Result, "Line segment C-E was incorrectly found to intersect A-C at: " + Result);

            Result = CA.Intersection(EC);
            Assert.IsNotNull(Result, "Line segment E-C was incorrectly found to not intersect C-A");
            Assert.IsTrue(CC == Result, "Line segment E-C was incorrectly found to intersect C-A at: " + Result);

            Result = CA.Intersection(CE);
            Assert.IsNotNull(Result, "Line segment C-E was incorrectly found to not intersect C-A");
            Assert.IsTrue(CC == Result, "Line segment C-E was incorrectly found to intersect C-A at: " + Result);

            Result = AC.Intersection(ED);
            Assert.IsNull(Result, "Line segment E-D was incorrectly found to intersect A-C at: " + Result);

            Result = AC.Intersection(DE);
            Assert.IsNull(Result, "Line segment D-E was incorrectly found to intersect A-C at: " + Result);

            Result = CA.Intersection(ED);
            Assert.IsNull(Result, "Line segment E-D was incorrectly found to intersect C-A at: " + Result);

            Result = CA.Intersection(DE);
            Assert.IsNull(Result, "Line segment D-E was incorrectly found to intersect C-A at: " + Result);

            Result = FG.Intersection(BF);
            Assert.IsNotNull(Result, "Line segment B-F was incorrectly found to not intersect F-G");
            Assert.IsTrue(FG == Result, "Line segment B-F was incorrectly found to intersect F-G at: " + Result);

            Result = BF.Intersection(FG);
            Assert.IsNotNull(Result, "Line segment F-G was incorrectly found to not intersect B-F");
            Assert.IsTrue(FG == Result, "Line segment F-G was incorrectly found to intersect B-F at: " + Result);

            Result = BG.Intersection(BF);
            Assert.IsNotNull(Result, "Line segment B-F was incorrectly found to not intersect B-G");
            Assert.IsTrue(BG == Result, "Line segment B-F was incorrectly found to intersect B-G at: " + Result);

            Result = BF.Intersection(BG);
            Assert.IsNotNull(Result, "Line segment B-G was incorrectly found to not intersect B-F");
            Assert.IsTrue(BG == Result, "Line segment B-G was incorrectly found to intersect B-F at: " + Result);

            Result = BG.Intersection(FG);
            Assert.IsNotNull(Result, "Line segment F-G was incorrectly found to not intersect B-G");
            Assert.IsTrue(new LineSegment(G, G) == Result, "Line segment F-G was incorrectly found to intersect B-G at: " + Result);

            Result = FG.Intersection(BG);
            Assert.IsNotNull(Result, "Line segment B-G was incorrectly found to not intersect B-F");
            Assert.IsTrue(new LineSegment(G, G) == Result, "Line segment B-G was incorrectly found to intersect B-F at: " + Result);

            Result = BM.Intersection(MB);
            Assert.IsNotNull(Result, "Line segment M-B was incorrectly found to not intersect B-M");
            Assert.IsTrue(MB == Result, "Line segment M-B was incorrectly found to intersect B-M at: " + Result);

            Result = MB.Intersection(BM);
            Assert.IsNotNull(Result, "Line segment B-M was incorrectly found to not intersect M-B");
            Assert.IsTrue(BM == Result, "Line segment B-M was incorrectly found to intersect M-B at: " + Result);

            Result = PF.Intersection(FB);
            Assert.IsNotNull(Result, "Line segment F-B was incorrectly found to not intersect P-F");
            Assert.IsTrue(FF == Result, "Line segment F-B was incorrectly found to intersect P-F at: " + Result);

            Result = PM.Intersection(GF);
            Assert.IsNull(Result, "Line segment G-F was incorrectly found to intersect P-M at: " + Result);

            Result = HT.Intersection(UV);
            Assert.IsNotNull(Result, "Line segment U-V was incorrectly found to not intersect H-T");
            Assert.IsTrue(UV == Result, "Line segment U-V was incorrectly found to intersect H-T at: " + Result);

            Result = UV.Intersection(HT);
            Assert.IsNotNull(Result, "Line segment H-T was incorrectly found to not intersect U-V");
            Assert.IsTrue(UV == Result, "Line segment H-T was incorrectly found to intersect U-T at: " + Result);

            Result = IJ.Intersection(IL);
            Assert.IsNotNull(Result, "Line segment I-L was incorrectly found to not intersect I-J");
            Assert.IsTrue(IJ == Result, "Line segment I-L was incorrectly found to intersect I-J at: " + Result);

            Result = IL.Intersection(IJ);
            Assert.IsNotNull(Result, "Line segment I-J was incorrectly found to not intersect I-L");
            Assert.IsTrue(IJ == Result, "Line segment I-J was incorrectly found to intersect I-L at: " + Result);

            Result = IL.Intersection(JK);
            Assert.IsNotNull(Result, "Line segment J-K was incorrectly found to not intersect I-L");
            Assert.IsTrue(JK == Result, "Line segment J-K was incorrectly found to intersect I-L at: " + Result);

            Result = JK.Intersection(IL);
            Assert.IsNotNull(Result, "Line segment I-L was incorrectly found to not intersect J-K");
            Assert.IsTrue(JK == Result, "Line segment I-L was incorrectly found to intersect J-K at: " + Result);

            Result = JL.Intersection(IK);
            Assert.IsNotNull(Result, "Line segment I-K was incorrectly found to not intersect J-L");
            Assert.IsTrue(JK == Result, "Line segment I-K was incorrectly found to intersect J-L at: " + Result);

            Result = IK.Intersection(JL);
            Assert.IsNotNull(Result, "Line segment J-L was incorrectly found to not intersect I-K");
            Assert.IsTrue(JK == Result, "Line segment J-L was incorrectly found to intersect I-K at: " + Result);

            Result = KM.Intersection(NO);
            Assert.IsNotNull(Result, "Line segment N-O was incorrectly found to not intersect K-M");
            Assert.IsTrue(new LineSegment(L, L) == Result, "Line segment K-M was incorrectly found to intersect N-O at: " + Result);

            Result = KM.Intersection(IJ);
            Assert.IsNull(Result, "Line segment I-J was incorrectly found to intersect K-M @ " + Result);

            Result = PQ.Intersection(BT);
            Assert.IsNull(Result, "Line segment B-T was incorrectly found to intersect P-Q @ " + Result);

            Result = new LineSegment(V, C).Intersection(BG);
            Assert.IsNull(Result, "Line segment B-G was incorrectly found to intersect C-V @ " + Result);

            Result = new LineSegment(M, D).Intersection(new LineSegment(N, C));
            Assert.IsNotNull(Result, "Line segment N-C was incorrectly found to intersect M-D @ " + Result);
            Assert.IsTrue(new LineSegment(new Coordinate(-1.818182f, 4.909091f), new Coordinate(-1.818182f, 4.909091f)) == Result, "Line segment N-C was incorrectly found to intersect M-D at: " + Result);

            Result = CJ.Intersection(BJ);
            Assert.IsNotNull(Result, "Line segment B-J was incorrectly found to intersect C-J @ " + Result);
            Assert.IsTrue(new LineSegment(J, J) == Result, "Line segment B-J was incorrectly found to intersect C-J at: " + Result);
        }

        [TestMethod]
        public void LineSegment_Member_Tests()
        {
            LineSegment Intersection;

            Assert.IsTrue(Segments.Length == SegmentNames.Length, "(" + Segments.Length + ") Line segments but (" + SegmentNames.Length + ") Line Segment names");

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\LineSegmentMemberTests.txt");

            int ab = 0;

            foreach (LineSegment AB in Segments)
            {
                int cd = 0;
                
                foreach (LineSegment CD in Segments)
                {
                    file.WriteLine((SegmentNames[ab] + AB).PadRight(40) + (SegmentNames[cd] + CD).PadLeft(40));
                    file.WriteLine("".PadLeft(80,'-'));

                    file.Write(("Aligned:".PadRight(18) + LineSegment.Collinear(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.WriteLine("Bends:".PadRight(18) + LineSegment.Bends(AB.A, AB.B, CD.A, CD.B).ToString());
                    file.Write(("Congruent:".PadRight(18) + LineSegment.Congruent(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.WriteLine("Contains:".PadRight(18) + LineSegment.Contains(AB.A, AB.B, CD.A, CD.B).ToString());
                    file.Write(("Extends:".PadRight(18) + LineSegment.Extends(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.WriteLine("Crosses:".PadRight(18) + LineSegment.Crosses(AB.A, AB.B, CD.A, CD.B).ToString());
                    file.Write(("Discontinues:".PadRight(18) + LineSegment.Outsects(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.WriteLine("Eschews:".PadRight(18) + LineSegment.Eschews(AB.A, AB.B, CD.A, CD.B).ToString());
                    file.Write(("Intersects:".PadRight(18) + LineSegment.Intersects(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.WriteLine("Overlaps:".PadRight(18) + LineSegment.Overlaps(AB.A, AB.B, CD.A, CD.B).ToString());
                    file.Write(("Parallel:".PadRight(18) + LineSegment.Parallel(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.WriteLine("Perpendicular:".PadRight(18) + LineSegment.Perpendicular(AB.A, AB.B, CD.A, CD.B).ToString());
                    file.WriteLine(("Touches:".PadRight(18) + LineSegment.Touches(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));

                    Intersection = LineSegment.Intersection(AB.A, AB.B, CD.A, CD.B);

                    file.WriteLine("Intersection:".PadRight(18) + (null == Intersection ? "{null}" : Intersection.ToString()));
                    file.WriteLine(" ");

                    cd++;
                }

                ab++;
            }

            file.Close();
        }

        static Coordinate A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V;

        static LineSegment AA, AB, AC, AD, AE, BA, BB, BC, BD, BE, BF, BG, BH, BJ, BM, BP, BT, BU, BV, CA, CB, CC, CD, CE, CJ, DA, DB, DC, DD, DE, EA, EB, EC, ED, EE, FB, FF, FG, FM, FP, GB, GF, GM, GP, HJ, HT, HU, HV, IJ, IK, IL, IM, JK, JL, JT, JU, JV, KL, KM, LM, LN, LO, LP, LQ, MB, MF, MG, MP, NL, NO, NP, NQ, OP, OQ, PB, PF, PG, PM, PQ, RS, TU, TV, UV;

        static LineSegment[] Segments;

        string[] SegmentNames = { "AA", "AB", "AC", "AD", "AE", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BJ", "BM", "BP", "BT", "BU", "BV", "CA", "CB", "CC", "CD", "CE", "CJ", "DA", "DB", "DC", "DD", "DE", "EA", "EB", "EC", "ED", "EE", "FB", "FF", "FG", "FM", "FP", "GB", "GF", "GM", "GP", "HJ", "HT", "HU", "HV", "IJ", "IK", "IL", "IM", "JK", "JL", "JT", "JU", "JV", "KL", "KM", "LM", "LN", "LO", "LP", "LQ", "MB", "MF", "MG", "MP", "NL", "NO", "NP", "NQ", "OP", "OQ", "PB", "PF", "PG", "PM", "PQ", "RS", "TU", "TV", "UV" };

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            A = new Coordinate(14, 17);
            B = new Coordinate(14, 12);
            C = new Coordinate(14, 6);
            D = new Coordinate(14, -3);
            E = new Coordinate(14, -12);
            F = new Coordinate(4, 12);
            G = new Coordinate(8, 12);
            H = new Coordinate(17, 15);
            I = new Coordinate(0, -12);
            J = new Coordinate(-4, -6);
            K = new Coordinate(-8, 0);
            L = new Coordinate(-12, 6);
            M = new Coordinate(-16, 12);
            N = new Coordinate(-15, 4);
            O = new Coordinate(-9, 8);
            P = new Coordinate(-3, 12);
            Q = new Coordinate(0, 14);
            R = new Coordinate(9, -12);
            S = new Coordinate(5, -16);
            T = new Coordinate(-14, -16);
            U = new Coordinate(2, 0);
            V = new Coordinate(8, 6);

            AA = new LineSegment(A, A);
            AB = new LineSegment(A, B);
            AC = new LineSegment(A, C);
            AD = new LineSegment(A, D);
            AE = new LineSegment(A, E);
            BA = new LineSegment(B, A);
            BB = new LineSegment(B, B);
            BC = new LineSegment(B, C);
            BD = new LineSegment(B, D);
            BE = new LineSegment(B, E);
            BF = new LineSegment(B, F);
            BG = new LineSegment(B, G);
            BH = new LineSegment(B, H);
            BJ = new LineSegment(B, J);
            BM = new LineSegment(B, M);
            BP = new LineSegment(B, P);
            BT = new LineSegment(B, T);
            BU = new LineSegment(B, U);
            BV = new LineSegment(B, V);
            CA = new LineSegment(C, A);
            CB = new LineSegment(C, B);
            CC = new LineSegment(C, C);
            CD = new LineSegment(C, D);
            CE = new LineSegment(C, E);
            CJ = new LineSegment(C, J);
            DA = new LineSegment(D, A);
            DB = new LineSegment(D, B);
            DC = new LineSegment(D, C);
            DD = new LineSegment(D, D);
            DE = new LineSegment(D, E);
            EA = new LineSegment(E, A);
            EB = new LineSegment(E, B);
            EC = new LineSegment(E, C);
            ED = new LineSegment(E, D);
            EE = new LineSegment(E, E);
            FB = new LineSegment(F, B);
            FG = new LineSegment(F, G);
            FF = new LineSegment(F, F);
            FM = new LineSegment(F, M);
            FP = new LineSegment(F, P);
            GB = new LineSegment(G, B);
            GF = new LineSegment(G, F);
            GM = new LineSegment(G, M);
            GP = new LineSegment(G, P);
            HJ = new LineSegment(H, J);
            HT = new LineSegment(H, T);
            HU = new LineSegment(H, U);
            HV = new LineSegment(H, V);
            IJ = new LineSegment(I, J);
            IK = new LineSegment(I, K);
            IL = new LineSegment(I, L);
            IM = new LineSegment(I, M);
            JK = new LineSegment(J, K);
            JL = new LineSegment(J, L);
            JT = new LineSegment(J, T);
            JU = new LineSegment(J, U);
            JV = new LineSegment(J, V);
            KL = new LineSegment(K, L);
            KM = new LineSegment(K, M);
            LM = new LineSegment(L, M);
            LN = new LineSegment(L, N);
            LO = new LineSegment(L, O);
            LP = new LineSegment(L, P);
            LQ = new LineSegment(L, Q);
            MB = new LineSegment(M, B);
            MF = new LineSegment(M, F);
            MG = new LineSegment(M, G);
            MP = new LineSegment(M, P);
            NL = new LineSegment(N, L);
            NO = new LineSegment(N, O);
            NP = new LineSegment(N, P);
            NQ = new LineSegment(N, Q);
            OP = new LineSegment(O, P);
            OQ = new LineSegment(O, Q);
            PB = new LineSegment(P, B);
            PF = new LineSegment(P, F);
            PG = new LineSegment(P, G);
            PM = new LineSegment(P, M);
            PQ = new LineSegment(P, Q);
            PM = new LineSegment(P, M);
            RS = new LineSegment(R, S);
            TU = new LineSegment(T, U);
            TV = new LineSegment(T, V);
            UV = new LineSegment(U, V);

            Segments = new LineSegment[] { AA, AB, AC, AD, AE, BA, BB, BC, BD, BE, BF, BG, BH, BJ, BM, BP, BT, BU, BV, CA, CB, CC, CD, CE, CJ, DA, DB, DC, DD, DE, EA, EB, EC, ED, EE, FB, FF, FG, FM, FP, GB, GF, GM, GP, HJ, HT, HU, HV, IJ, IK, IL, IM, JK, JL, JT, JU, JV, KL, KM, LM, LN, LO, LP, LQ, MB, MF, MG, MP, NL, NO, NP, NQ, OP, OQ, PB, PF, PG, PM, PQ, RS, TU, TV, UV };
        }
    }
}
