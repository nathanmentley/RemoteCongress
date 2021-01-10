for i in {1..157}
do
    id=$(printf "%05d" $i)
    wget "https://www.senate.gov/legislative/LIS/roll_call_votes/vote1162/vote_116_2_$id.xml"
done
