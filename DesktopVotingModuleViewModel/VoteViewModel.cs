
        public VoteViewModel()
        {
            user = PageController.User;
            ballot = Task.Run(async () => {return await API.GetBallots(user); }).Result;
            CandidatesSingleton.candidatesCollection = Task.Run(async () => { return await API.GetCandidateNamesForBallot(ballot, user); }).Result;
            //ballot.candidates = candidatesCollection.ToList();
            candidatesCollection = CandidatesSingleton.candidatesCollection;
        }
        public ICommand VoteCandidateCommand
        {
            get
            {
                return new VoteCandidate(this);
            }
        }

        public void Vote()
        {
            PageController.PageSource = "AfterVotePage.xaml";
        }

        public ICommand BackToStartPageCommand
        {
            get
            {
                return new BackToStartPage(this);
            }
        }

        public void Back()
        {
            PageController.PageSource = "MenuPage.xaml";
        }

       