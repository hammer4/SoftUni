import React from 'react';

import MovieAddActions from '../actions/MovieAddActions';
import MovieAddStore from '../stores/MovieAddStore';

export default class AddMovie extends React.Component {
    constructor(props) {
        super(props);

        this.state = MovieAddStore.getState();

        this.onChange = this.onChange.bind(this);
    }

    onChange(state) {
        this.setState(state);
    }

    componentDidMount() {
        MovieAddStore.listen(this.onChange);
    }

    componentWillUnmount() {
        MovieAddStore.unlisten(this.onChange);
    }

    handleSubmit(e) {
        e.preventDefault();

        let name = this.state.name.trim();
        let genres = this.state.genres;
        if (!name) {
           MovieAddActions.nameValidationFail();
        }
        if (genres.length === 0) {
            MovieAddActions.genresValidationFail();
        }

        if (name) {
            let data = {
                name: this.state.name,
                description: this.state.description,
                genres: this.state.genres,
            };
            MovieAddActions.addMovie(data);
        }
    }

    render() {
        return (
            <div className='container'>
                <div className='row flipInX animated'>
                    <div className='col-sm-8'>
                        <div className='panel panel-default'>
                            <div className='panel-heading'>Add Movie</div>
                            <div className='panel-body'>
                                <form onSubmit={  this.handleSubmit.bind(this)  }>
                                    <div className={ 'form-group ' + this.state.nameValidationState }>
                                        <label className='control-label'>Name</label>
                                        <input type='text' className='form-control' ref='nameTextField'
                                               value={ this.state.name }
                                               onChange={ MovieAddActions.handleNameChange } autoFocus/>
                                        <span className='help-block'>{ this.state.helpBlock }</span>
                                    </div>
                                    <div className='form-group'>
                                        <label className='control-label'>Description</label>
                                        <textarea className='form-control'
                                                  rows="5"
                                                  value={ this.state.description }
                                                  onChange={ MovieAddActions.handleDescriptionChange } />
                                    </div>
                                    <div className={ 'form-group ' + this.state.genresValidationState }>
                                        <div className='checkbox checkbox-inline'>
                                            <input type='checkbox' name='genres' id='action' value='Action'
                                                   checked={ this.state.genres.indexOf('Action') !== -1 }
                                                   onChange={ MovieAddActions.handleGenresChange }/>
                                            <label htmlFor='action'>Action</label>
                                        </div>
                                        <div className='checkbox checkbox-inline'>
                                            <input type='checkbox' name='genres' id='horror' value='Horror'
                                                   checked={ this.state.genres.indexOf('Horror') !== -1 }
                                                   onChange={ MovieAddActions.handleGenresChange }/>
                                            <label htmlFor='horror'>Horror</label>
                                        </div>
                                        <div className='checkbox checkbox-inline'>
                                            <input type='checkbox' name='genres' id='sci-fi' value='Sci-fi'
                                                   checked={ this.state.genres.indexOf('Sci-fi') !== -1 }
                                                   onChange={ MovieAddActions.handleGenresChange }/>
                                            <label htmlFor='sci-fi'>Sci-fi</label>
                                        </div>
                                        <div className='checkbox checkbox-inline'>
                                            <input type='checkbox' name='genres' id='fantasy' value='Fantasy'
                                                   checked={ this.state.genres.indexOf('Fantasy') !== -1 }
                                                   onChange={ MovieAddActions.handleGenresChange }/>
                                            <label htmlFor='fantasy'>Fantasy</label>
                                        </div>
                                        <div className='checkbox checkbox-inline'>
                                            <input type='checkbox' name='genres' id='romance' value='Romance'
                                                   checked={ this.state.genres.indexOf('Romance') !== -1 }
                                                   onChange={ MovieAddActions.handleGenresChange }/>
                                            <label htmlFor='romance'>Romance</label>
                                        </div>
                                        <div className='checkbox checkbox-inline'>
                                            <input type='checkbox' name='genres' id='thriller' value='Thriller'
                                                   checked={ this.state.genres.indexOf('Thriller') !== -1 }
                                                   onChange={ MovieAddActions.handleGenresChange }/>
                                            <label htmlFor='thriller'>Thriller</label>
                                        </div>
                                        <div className='checkbox checkbox-inline'>
                                            <input type='checkbox' name='genres' id='adventure' value='Adventure'
                                                   checked={ this.state.genres.indexOf('Adventure') !== -1 }
                                                   onChange={ MovieAddActions.handleGenresChange }/>
                                            <label htmlFor='adventure'>Adventure</label>
                                        </div>
                                    </div>
                                    <button type='submit' className='btn btn-primary'>Submit</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

}

