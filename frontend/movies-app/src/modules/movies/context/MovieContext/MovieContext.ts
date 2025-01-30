import { createContext } from 'react';
import { Movie } from '../../models';

export interface IMovieContext {
    searchMovieName?: string,
    moviesFound: Movie[],
    updateMoviesFound: (value?: Movie[]) => void
    updateSearchMovieName: (value?: string) => void
}

export const MovieContext = createContext<IMovieContext>({
    searchMovieName: '',
    updateSearchMovieName: (value?: string) => { },
    updateMoviesFound: (value?: Movie[]) => { },
    moviesFound: []
});