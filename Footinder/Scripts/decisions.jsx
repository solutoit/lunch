var RestaurantView = React.createClass({
	render:function() {
		if(!this.props.restaurant) return;

		return (
		<div className="rest">
			<div className="pic"><img src={this.props.restaurant.LogoUri}/></div>
			<div className="details">
				<div className="title">{this.props.restaurant.Name}</div>
			</div>
		</div>
		);
	}
});

var App = React.createClass({
	getInitialState: function() {
        $.ajax('/Restaurants', {
            success: function(data) {
                this.setState({restaurants:data, currentRest: 0});
            }.bind(this)
        });
        
        return {currentRest: -1, restaurants: []};
	},
    getCurrentRest: function() {
        if(this.state.currentRest < 0) return undefined;
        return this.state.restaurants[this.state.currentRest];
    },
	render: function() {
		return (
		<div>
			<RestaurantView restaurant={this.getCurrentRest()} />
		</div>
		);
	}
});

React.render(<App />,document.getElementById('content'));