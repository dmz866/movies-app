import { ClipLoader } from 'react-spinners';
import { BasicContainer } from '../../../common/components';
import { ActorCard } from '../../components';
import { useActorsPage } from './useActorsPage';

export const ActorsPage = () => {
    const { searchActorName, handleInput, isLoading, handleSearch, noActorFound, actors } = useActorsPage();

    return (
        <BasicContainer>
            <div className="mx-32">
                <div className="justify-center flex-row p-4">
                    <p className="font-semibold text-white w-full">Search Actors by Name:</p>
                    <div className='flex'>
                        <input defaultValue={searchActorName} name='searchActorName' type="text" className="text-black py-1 px-2 w-full border rounded-lg" onChange={handleInput} />
                        <button className="px-4 mx-2 border rounded-lg bg-white py-1" onClick={() => handleSearch(searchActorName!)}>Search</button>
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
                    {noActorFound && <p>No Actors found</p>}
                    {actors?.map((p, indx) => {
                        return <ActorCard key={`${p.name}-${indx}`} actor={p} />
                    })}
                </div>
            </div>
        </BasicContainer>
    );
};