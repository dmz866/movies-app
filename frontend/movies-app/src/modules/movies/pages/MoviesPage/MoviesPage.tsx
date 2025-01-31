import { ClipLoader } from 'react-spinners';
import { BasicContainer } from '../../../common/components';
import { MovieCard } from '../../components';
import { useMoviesPage } from './useMoviesPage';

export const MoviesPage = () => {
    const { searchMovieName, handleInput, isLoading, handleSearch, noMovieFound, movies } = useMoviesPage();

    return (
        <BasicContainer>
            <div className="mx-32">
                <div className="justify-center flex-row p-4">
                    <p className="font-semibold text-white w-full">Search Movies by Name:</p>
                    <div className='flex'>
                        <input defaultValue={searchMovieName} name='searchMovieName' type="text" className="text-black py-1 px-2 w-full border rounded-lg" onChange={handleInput} />
                        <button className="px-4 mx-2 border rounded-lg bg-white py-1" onClick={() => handleSearch(searchMovieName!)}>Search</button>
                    </div>
                </div>
                <div className="flex justify-center">
                    {
                        isLoading &&
                        <ClipLoader
                            loading={isLoading}
                            size={150}
                            aria-label="Loading Spinner"
                            color='#FFFFFF'
                            data-testid="loader"
                        />
                    }
                </div>
                <div className="p-3 flex justify-center flex-wrap gap-8">
                    {noMovieFound && <p className='text-white'>No Movies found</p>}
                    {movies?.map((p, indx) => {
                        return <MovieCard key={`${p.name}-${indx}`} movie={p} />
                    })}
                </div>
            </div>
        </BasicContainer>
    );
};