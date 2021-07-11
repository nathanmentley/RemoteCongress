for i in {1..252}
do
    id=$(printf "%05d" $i)
    wget "https://www.senate.gov/legislative/LIS/roll_call_votes/vote1171/vote_117_1_$id.xml"
done
