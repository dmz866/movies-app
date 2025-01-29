import { createContext } from 'react';

export interface IMovieContext {
    searchMovieName?: string,
    updateSearchMovieName: (value?: string) => void
}

export const MovieContext = createContext<IMovieContext>({
    searchMovieName: '',
    updateSearchMovieName: (value?: string) => { }
});